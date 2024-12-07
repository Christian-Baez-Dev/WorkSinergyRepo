using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using WorkSynergy.Core.Application.DTOs.Entities.Post;
using WorkSynergy.Core.Application.Features.Posts.Commands.CreatePost;
using WorkSynergy.Core.Application.Features.Posts.Commands.DeletePost;
using WorkSynergy.Core.Application.Features.Posts.Commands.UpdatePost;
using WorkSynergy.Core.Application.Features.Posts.Queries.GetAllPost;
using WorkSynergy.Core.Application.Features.Posts.Queries.GetAllPostByUserId;
using WorkSynergy.Core.Application.Features.Posts.Queries.GetByIdPost;
using WorkSynergy.Core.Application.Interfaces.Services;
using WorkSynergy.WebApi.Helpers;

namespace WorkSynergy.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    //[Authorize]
    [SwaggerTag("Controller for the Posts")]
    public class PostController : BaseApiController
    {
        private readonly IAccountService _accountService;

        public PostController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a new Post",
            Description = "This endpoint is responsible for the creation of a new Post"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreatePostCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return ResponseHelper.CreateResponse(await Mediator.Send(command), this);

        }
        [HttpGet]
        [SwaggerOperation(
        Summary = "Get all Post",
        Description = "This endpoint is responsible for the retrieve of all post"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ManyPostsResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(GetAllPostQuery query)
        {
            var result = await Mediator.Send(query);
            foreach (var item in result.Data)
            {
                var userResponse = await _accountService.GetByIdAsyncDTO(item.CreatorUserId);
                item.Creator = userResponse.Data;
            }
            return ResponseHelper.CreateResponse(result, this);
        }
        [HttpGet("GetByUser/{id}")]
        [SwaggerOperation(
        Summary = "Get all Post",
        Description = "This endpoint is responsible for the retrieve of all post"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ManyPostsResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(GetAllPostByUserIdQuery query)
        {
            var result = await Mediator.Send(query);
            foreach (var item in result.Data)
            {
                var userResponse = await _accountService.GetByIdAsyncDTO(item.CreatorUserId);
                item.Creator = userResponse.Data;
            }
            return ResponseHelper.CreateResponse(result, this);
        }
        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Get one post by id",
        Description = "This endpoint is responsible for the retrieve of an post based on it's Id"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(GetByIdPostQuery query)
        {
            var result = await Mediator.Send(query);
            var userResponse = await _accountService.GetByIdAsyncDTO(result.Data.CreatorUserId);
            result.Data.Creator = userResponse.Data;
            return ResponseHelper.CreateResponse(result, this);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
               Summary = "Update for posts",
               Description = "Recieve the parameter needed for the update of a post"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, UpdatePostCommand command)
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
            Summary = "Delete post",
            Description = "Recieve the Id to delete the post"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            return ResponseHelper.CreateResponse(await Mediator.Send(new DeletePostCommand { Id = id }), this);
        }
    }
}
