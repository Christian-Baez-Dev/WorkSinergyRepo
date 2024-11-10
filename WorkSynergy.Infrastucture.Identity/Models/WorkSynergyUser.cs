using Microsoft.AspNetCore.Identity;

namespace WorkSynergy.Infrastucture.Identity.Models
{
    public class WorkSynergyUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Uuid { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
        public string? UserImagePath { get; set; }

    }
}
