using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace WorkSynergy.Core.Application.Dtos.Account
{
    /// <summary>
    /// Parámetros para la creación del usuario
    /// </summary>
    public class UserRegisterRequest
    {
        [SwaggerParameter(Description = "El username del usuario")]
        public string Username { get; set; }
        [SwaggerParameter(Description = "Descripcion del usuario")]
        public string Description { get; set; }
        [SwaggerParameter(Description = "El correo electronico del usuario")]
        public string Email { get; set; }
        [SwaggerParameter(Description = "Fecha de nacimiento del usuario")]
        public DateTime BirthDate { get; set; }
        [SwaggerParameter(Description = "El nombre de usuario")]
        public string FirstName { get; set; }
        [SwaggerParameter(Description = "El apellido del usuario")]
        public string LastName { get; set; }
        [SwaggerParameter(Description = "El documento de identidad del usuario")]
        public string? Password { get; set; }
        [SwaggerParameter(Description = "La confirmacion de la contraseña del usuario")]
        public string? ConfirmPassword { get; set; }
        [SwaggerParameter(Description = "El rol del usuario")]
        public string Role { get; set; }
        [SwaggerParameter(Description = "Link de la foto de perfil del usuario")]
        public List<int>? Abilities { get; set; }
        [SwaggerParameter(Description = "Link de la foto de perfil del usuario")]
        public IFormFile? UserImage { get; set; }


    }
}
