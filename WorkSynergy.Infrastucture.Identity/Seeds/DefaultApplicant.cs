using Microsoft.AspNetCore.Identity;
using WorkSynergy.Core.Application.Enums;
using WorkSynergy.Infrastucture.Identity.Models;

namespace WorkSynergy.Infrastucture.Identity.Seeds
{
    public static class DefaultApplicant
    {
        public static async Task SeedAsync(UserManager<WorkSynergyUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            WorkSynergyUser defaultUser = new();
            defaultUser.UserName = "defaultApplicant";
            defaultUser.Email = "defaultapplicant@gmail.com";
            defaultUser.FirstName = "Default";
            defaultUser.LastName = "Applicant";
            defaultUser.EmailConfirmed = true;
            defaultUser.PhoneNumberConfirmed = true;
            defaultUser.IsActive = true;
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, nameof(UserRoles.Applicant));
                }
            }

        }
    }
}
