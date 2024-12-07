using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using WorkSynergy.Core.Application.DTOs.Entities.Contract;
using WorkSynergy.Core.Application.Features.Contracts.Commands.DownloadDeliverable;
using WorkSynergy.Core.Application.Features.Contracts.Commands.PayContract;
using WorkSynergy.Core.Application.Features.Contracts.Queries.GetAllContract;
using WorkSynergy.Core.Application.Features.Contracts.Queries.GetByIdContract;
using WorkSynergy.Core.Application.Features.Currencies.Commands.UploadFixedPriceMilestoneDeliverable;
using WorkSynergy.Core.Application.Features.Currencies.Commands.UploadHourlyMilestoneDeliverable;
using WorkSynergy.Core.Application.Features.Currencies.Queries.GetAllCurrency;
using WorkSynergy.WebApi.Helpers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WorkSynergy.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    //[Authorize]
    [SwaggerTag("Controller for the contracts")]
    public class ContractController : BaseApiController
    {
        [HttpPost("FixedPriceMilestone")]
        [SwaggerOperation(
            Summary = "Upload fixed price",
            Description = "Upload fixed price"
        )]
        [Consumes(MediaTypeNames.Multipart.FormData)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UploadFixedPriceDeliverable(UploadFixedPriceMilestoneDeliverableCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return ResponseHelper.CreateResponse(await Mediator.Send(command), this);
        }
        [HttpPost("HourlyMilestone")]
        [SwaggerOperation(
            Summary = "Upload fixed price",
            Description = "Upload fixed price"
        )]
        [Consumes(MediaTypeNames.Multipart.FormData)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UploadHourlyDeliverable(UploadHourlyMilestoneDeliverableCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return ResponseHelper.CreateResponse(await Mediator.Send(command), this);
        }
        [HttpPatch("PayContract")]
        [SwaggerOperation(
            Summary = "Pay a certain amount to a contract",
            Description = "Pay a certain amount to a contract"
        )]
        [Consumes(MediaTypeNames.Multipart.FormData)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PayContract(PayContractCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return ResponseHelper.CreateResponse(await Mediator.Send(command), this);
        }
        [HttpGet("Download")]
        [SwaggerOperation(
             Summary = "Download a deliverable",
             Description = "This endpoint is responsible to the download of a deliverable"
         )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(FileResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFile(DownloadDeliverableCommand query)
        {
            return await Mediator.Send(query);
        }
        [HttpGet("{id}")]
        [SwaggerOperation(
             Summary = "Get contract by id",
             Description = "This endpoint is responsible to search a certain contract by its id"
         )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ContractResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(GetByIdContractQuery query)
        {
            return ResponseHelper.CreateResponse(await Mediator.Send(query), this);
        }
        [HttpGet("")]
        [SwaggerOperation(
             Summary = "Get contract by id",
             Description = "This endpoint is responsible to search a certain contract by its id"
         )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ManyContractResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(GetAllContractQuery query)
        {
            return ResponseHelper.CreateResponse(await Mediator.Send(query), this);
        }

    }
}
