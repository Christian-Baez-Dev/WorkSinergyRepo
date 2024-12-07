using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using WorkSynergy.Core.Application.DTOs.Entities.JobOffer;
using WorkSynergy.Core.Application.Features.JobOffers.Commands.CreateJobOfferCommand;
using WorkSynergy.Core.Application.Features.JobOffers.Commands.DeleteJobOffer;
using WorkSynergy.Core.Application.Features.JobOffers.Queries.GetAllJobOffer;
using WorkSynergy.Core.Application.Features.JobOffers.Queries.GetAllJobOfferByClient;
using WorkSynergy.Core.Application.Features.JobOffers.Queries.GetAllJobOfferByFreelancer;
using WorkSynergy.Core.Application.Features.JobOffers.Queries.GetByIdJobOffer;
using WorkSynergy.Core.Application.Interfaces.Services;
using WorkSynergy.WebApi.Helpers;

namespace WorkSynergy.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    //[Authorize]
    [SwaggerTag("Controller for the job offers")]
    public class JobOfferController : BaseApiController
    {
        private readonly IAccountService _accountService;

        public JobOfferController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Creation of a new job offer",
            Description = "Recieve the parameter for the creation of a new job offer"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreateJobOfferCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return ResponseHelper.CreateResponse(await Mediator.Send(command), this);
        }
        [HttpGet]
        [SwaggerOperation(
             Summary = "Get all Job Offers",
             Description = "This endpoint is responsible for the retrieve of all Job Offers"
         )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ManyJobOffersResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(GetAllJobOfferQuery query)
        {
            return ResponseHelper.CreateResponse(await Mediator.Send(query), this);
        }
        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Get one Job Offer by id",
        Description = "This endpoint is responsible for the retrieve of an job offer based on it's Id"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JobOfferResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(GetByIdJobOfferQuery query)
        {
            var result = await Mediator.Send(query);
            var clientResponse = await _accountService.GetByIdAsyncDTO(result.Data.ClientUserId);
            result.Data.Client = clientResponse.Data;
            var freelancerResponse = await _accountService.GetByIdAsyncDTO(result.Data.FreelancerId);
            result.Data.Freelancer = freelancerResponse.Data;
            return ResponseHelper.CreateResponse(result, this);
        }

        [HttpGet("GetByClient/{id}")]
        [SwaggerOperation(
            Summary = "Get many Job Offer by the client id",
            Description = "This endpoint is responsible for the retrieve all the job offers created by a client"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ManyJobOffersResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(GetAllJobOfferByClientQuery query)
        {
            var result = await Mediator.Send(query);
            foreach (var item in result.Data)
            {
                var userResponse = await _accountService.GetByIdAsyncDTO(item.FreelancerId);
                item.Freelancer = userResponse.Data;
            }
            return ResponseHelper.CreateResponse(result, this);
        }

        [HttpGet("GetByFreelancer/{id}")]
        [SwaggerOperation(
            Summary = "Get many Job Offer by the freelancer id",
            Description = "This endpoint is responsible for the retrieve all the job offers sended to a freelancer"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ManyJobOffersResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(GetAllJobOfferByFreelancerQuery query)
        {
            var result = await Mediator.Send(query);
            foreach (var item in result.Data)
            {
                var userResponse = await _accountService.GetByIdAsyncDTO(item.ClientUserId);
                item.Client = userResponse.Data;
            }
            return ResponseHelper.CreateResponse(result, this);
        }
        [HttpPatch("{id}")]
        [SwaggerOperation(
            Summary = "Change status Job Offer",
            Description = "Recieve the paremeter to change the status of a job offer"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult>ChangeStatus (int id, [FromBody]ChangeStatusJobOfferCommand command)
        {
            if (command.JobOfferId != id)
                return BadRequest("The Id in the url and the id in the body doesn't match");

            return ResponseHelper.CreateResponse(await Mediator.Send(command), this);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete Job Offer",
            Description = "Recieve the Id to delete the Job Offers"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            return ResponseHelper.CreateResponse(await Mediator.Send(new DeleteJobOfferCommand { Id = id }), this);
        }

    }
}
