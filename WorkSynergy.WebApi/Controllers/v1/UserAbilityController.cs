using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using WorkSynergy.Core.Application.DTOs.Entities.Ability;
using WorkSynergy.Core.Application.DTOs.Entities.UserAbility;
using WorkSynergy.Core.Application.Features.Abilities.Commands.DeleteAbility;
using WorkSynergy.Core.Application.Features.Abilities.Queries.GetAllAbilities;
using WorkSynergy.Core.Application.Features.UserAbilities.Commands;
using WorkSynergy.Core.Application.Features.UserAbilities.Queries.GetAllUserAbility;
using WorkSynergy.Core.Application.Features.UserAbilities.Queries.GetByIdUserAbility;
using WorkSynergy.WebApi.Helpers;

namespace WorkSynergy.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    //[Authorize]
    [SwaggerTag("Controller for the User Abilities")]
    public class UserAbilityController : BaseApiController
    {
        [HttpPost]
        [SwaggerOperation(
            Summary = "Creation of a new user ability",
            Description = "Recieve the parameter for the creation of a new ability"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreateUserAbilityCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return ResponseHelper.CreateResponse(await Mediator.Send(command), this);
        }
        [HttpGet]
        [SwaggerOperation(
     Summary = "Get all User Abilities",
     Description = "This endpoint is responsible for the retrieve of all User Abilities from a single user"
     )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ManyUserAbilityResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(GetAllUserAbilityQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Get one User Ability by id",
        Description = "This endpoint is responsible for the retrieve of an user ability based on it's Id"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserAbilityResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(GetByIdUserAbilityQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        //[HttpPut("{id}")]
        //[SwaggerOperation(
        //       Summary = "Update for Tags",
        //       Description = "Recieve the parameter needed for the update of the Abilities"
        //)]
        //[Consumes(MediaTypeNames.Application.Json)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> Put(int id, UpdateAbilityCommand command)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }
        //    if (id != command.Id)
        //    {
        //        return BadRequest();
        //    }

        //    return Ok(await Mediator.Send(command));
        //}


        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete User Ability",
            Description = "Recieve the Id to delete the User Abilities"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteUserAbilityCommand { Id = id });
            return NoContent();
        }

    }
}
