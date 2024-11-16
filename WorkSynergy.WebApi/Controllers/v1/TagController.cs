﻿using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using WorkSynergy.Core.Application.DTOs.Entities.Tag;
using WorkSynergy.Core.Application.Features.Tags.Commands.CreateTagCommand;
using WorkSynergy.Core.Application.Features.Tags.Commands.DeleteTag;
using WorkSynergy.Core.Application.Features.Tags.Commands.UpdateTag;
using WorkSynergy.Core.Application.Features.Tags.Queries.GetAllTag;
using WorkSynergy.Core.Application.Features.Tags.Queries.GetByIdTag;

namespace WorkSynergy.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    //[Authorize]
    [SwaggerTag("Controller for the Tags")]
    public class TagController : BaseApiController
    {
        [HttpPost]
        [SwaggerOperation(
            Summary = "Creation of a new tag",
            Description = "Recieve the parameter for the creation of a new tag"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody]CreateTagCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(await Mediator.Send(command));
        }
        [HttpGet]
        [SwaggerOperation(
     Summary = "Get all Tags",
     Description = "This endpoint is responsible for the retrieve of all Tags"
     )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TagResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(GetAllTagQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Get one Tags by id",
        Description = "This endpoint is responsible for the retrieve of an Tags based on it's Id"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TagResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(GetByIdTagQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
               Summary = "Update for Tags",
               Description = "Recieve the parameter needed for the update of a Tags"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, UpdateTagCommand command)
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
            Summary = "Delete Tags",
            Description = "Recieve the Id to delete the Tags"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTagCommand { Id = id });
            return NoContent();
        }

    }
}
