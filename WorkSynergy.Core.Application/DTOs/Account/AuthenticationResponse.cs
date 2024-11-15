using System.Text.Json.Serialization;

namespace WorkSynergy.Core.Application.Dtos.Account
{
    public class AuthenticationResponse
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public bool IsVerified { get; set; }
        public string? UserImagePath { get; set; }
        public bool HasError { get; set; }
        public string? Error { get; set; }
        public string? JWToken { get; set; }
        [JsonIgnore]
        public string? RefreshToken { get; set; }


    }
}
