using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using WorkSynergy.Core.Application.DTOs.Entities.JobApplication;
using WorkSynergy.Core.Application.Features.JobApplications.Commands.ChangeStatusJobApplication;
using WorkSynergy.Core.Application.Features.JobApplications.Commands.CreateJobApplication;
using WorkSynergy.Core.Application.Features.JobApplications.Queries.GetAllJobApplicationByPost;
using WorkSynergy.Core.Application.Features.JobApplications.Queries.GetAllJobApplicationByUser;
using WorkSynergy.Core.Application.Interfaces.Services;
using WorkSynergy.WebApi.Helpers;

namespace WorkSynergy.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    //[Authorize]
    [SwaggerTag("Controller for the job applications")]
    public class JobApplciationController : BaseApiController
    {
        private readonly IAccountService _accountService;

        public JobApplciationController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Creation of a new job application",
            Description = "Recieve the parameter for the creation of a new job application"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreateJobApplicationCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return ResponseHelper.CreateResponse(await Mediator.Send(command), this);
        }

        [HttpGet("GetByPost/{id}")]
        [SwaggerOperation(
        Summary = "Get many job application based on a post id",
        Description = "This endpoint is responsible for the retrieve all the job applications of an post"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ManyJobApplicationResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByPost(GetAllJobApplicationByPostQuery query)
        {
            var result = await Mediator.Send(query);
            if (result != null && result.Data.Count > 0)
            {
                foreach (var item in result.Data)
                {
                    var userResponse = await _accountService.GetByIdAsyncDTO(item.ApplicantId);
                    item.User = userResponse.Data;
                }
            }
            return ResponseHelper.CreateResponse(result, this);
        }
        [HttpGet("GetByUser/{id}")]
        [SwaggerOperation(
            Summary = "Get many job application based on a freelancer id",
            Description = "This endpoint is responsible for the retrieve all the job applications of an freelancer"
            )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ManyJobApplicationResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByUser(GetAllJobApplicationByUserQuery query)
        {
            var result = await Mediator.Send(query);
            if (result != null && result.Data.Count > 0)
            {
                foreach (var item in result.Data)
                {
                    var userResponse = await _accountService.GetByIdAsyncDTO(item.Post.CreatorUserId);
                    item.User = userResponse.Data;
                }
            }
            return ResponseHelper.CreateResponse(result, this);
        }
        [HttpGet("Get/{id}")]
        [SwaggerOperation(
            Summary = "Get one job application based on a its id",
            Description = "This endpoint is responsible for the retrieve a the job application"
            )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ManyJobApplicationResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(GetJobApplicationByIdQuery query)
        {
            var result = await Mediator.Send(query);
            if (result != null)
            {

                var userResponse = await _accountService.GetByIdAsyncDTO(result.Data.Post.CreatorUserId);
                result.Data.User = userResponse.Data;

            }
            return ResponseHelper.CreateResponse(result, this);
        }
        [HttpPut]
        [SwaggerOperation(
               Summary = "Change status of a job application",
               Description = "Recieve the parameter needed to change the status of a job application"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(ChangeStatusJobApplicationCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            return ResponseHelper.CreateResponse(await Mediator.Send(command), this);
        }


    }
}
