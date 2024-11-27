using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using WorkSynergy.Core.Application.DTOs.Entities.Ability;
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
    [SwaggerTag("Controller for the Abilities")]
    public class AbilityController : BaseApiController
    {
        [HttpPost]
        [SwaggerOperation(
            Summary = "Creation of a new ability",
            Description = "Recieve the parameter for the creation of a new ability"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreateAbilityCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return ResponseHelper.CreateResponse(await Mediator.Send(command), this);
        }
        [HttpGet]
        [SwaggerOperation(
     Summary = "Get all Abilities",
     Description = "This endpoint is responsible for the retrieve of all Abilities"
     )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ManyAbilityResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(GetAllAbilityQuery query)
        {
            return ResponseHelper.CreateResponse(await Mediator.Send(query), this);
        }
        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Get one Ability by id",
        Description = "This endpoint is responsible for the retrieve of an ability based on it's Id"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AbilityResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(GetByIdAbilityQuery query)
        {
            return ResponseHelper.CreateResponse(await Mediator.Send(query), this);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
               Summary = "Update for Abilities",
               Description = "Recieve the parameter needed for the update of the Abilities"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, UpdateAbilityCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (id != command.Id)
            {
                return BadRequest();
            }

            return ResponseHelper.CreateResponse(await Mediator.Send(command), this);
        }


        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete Ability",
            Description = "Recieve the Id to delete the Abilities"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteAbilityCommand { Id = id });
            return ResponseHelper.CreateResponse(await Mediator.Send(new DeleteAbilityCommand { Id = id }), this);
        }

    }
}
