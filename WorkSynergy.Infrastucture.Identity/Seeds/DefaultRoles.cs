using Microsoft.AspNetCore.Identity;
using WorkSynergy.Core.Application.Enums;
using WorkSynergy.Infrastucture.Identity.Models;

namespace WorkSynergy.Infrastucture.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<WorkSynergyUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(UserRoles.Applicant.ToString()));
            await roleManager.CreateAsync(new IdentityRole(UserRoles.Contractor.ToString()));
        }
    }
}
