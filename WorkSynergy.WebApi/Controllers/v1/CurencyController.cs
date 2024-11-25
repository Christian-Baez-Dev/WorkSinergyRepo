using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using WorkSynergy.Core.Application.DTOs.Entities.Ability;
using WorkSynergy.Core.Application.DTOs.Entities.Currency;
using WorkSynergy.Core.Application.Features.Abilities.Commands.CreateAbilitiesCommand;
using WorkSynergy.Core.Application.Features.Abilities.Commands.DeleteAbility;
using WorkSynergy.Core.Application.Features.Abilities.Commands.UpdateAbility;
using WorkSynergy.Core.Application.Features.Abilities.Queries.GetAllAbilities;
using WorkSynergy.Core.Application.Features.Abilities.Queries.GetByIdAbilities;
using WorkSynergy.WebApi.Helpers;

namespace WorkSynergy.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    //[Authorize]
    [SwaggerTag("Controller for the Currencies")]
    public class CurrencyController : BaseApiController
    {
        [HttpPost]
        [SwaggerOperation(
            Summary = "Creation of a new currency",
            Description = "Recieve the parameter for the creation of a new currency"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreateCurrencyCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return ResponseHelper.CreateResponse(await Mediator.Send(command), this);
        }
        [HttpGet]
        [SwaggerOperation(
     Summary = "Get all Currencies",
     Description = "This endpoint is responsible for the retrieve of all Currencies"
     )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ManyCurrencyResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(GetAllCurrencyQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Get one Currency by id",
        Description = "This endpoint is responsible for the retrieve of an currency based on it's Id"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CurrencyResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(GetByIdCurrencyQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
               Summary = "Update for Currencies",
               Description = "Recieve the parameter needed for the update of the Currencies"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, UpdateCurrencyCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (id != command.Id)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }


        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete Currency",
            Description = "Recieve the Id to delete the Currencies"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteAbilityCommand { Id = id });
            return NoContent();
        }

    }
}
