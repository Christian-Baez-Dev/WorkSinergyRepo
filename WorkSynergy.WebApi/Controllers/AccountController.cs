using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using WorkSynergy.Core.Application.Dtos.Account;
using WorkSynergy.Core.Application.Interfaces.Services;

namespace WorkSynergy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Sistema de membresia")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("authenticate")]
        [SwaggerOperation(
         Summary = "Login de usuario",
         Description = "Autentica un usuario en el sistema y le retorna un JWT"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> AuthenticateAsync([FromBody] AuthenticationRequest request)
        {
            return Ok(await _accountService.AuthenticateAsync(request));
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
             Summary = "Get user by id",
             Description = "Find a user by id"
            )]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _accountService.GetByIdAsyncDTO(id));
        }
        [HttpGet("GetByRole/{role}")]
        [SwaggerOperation(
         Summary = "Get user by id",
         Description = "Find a user by id"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetByRole(string role)
        {
            return Ok(await _accountService.GetAllByRoleDTO(role));
        }

        [HttpPost("registerUser")]
        [SwaggerOperation(
            Summary = "Creacion de usuarios",
            Description = "Recibe los parametros necesarios para crear un usuario"
        )]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> RegisterUserAsync([FromBody] UserRegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _accountService.RegisterUserAsync(request, origin));
        }
    }
}
