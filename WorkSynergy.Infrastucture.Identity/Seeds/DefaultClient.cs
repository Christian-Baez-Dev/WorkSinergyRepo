using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSynergy.Core.Application.Enums;
using WorkSynergy.Infrastucture.Identity.Models;

namespace WorkSynergy.Infrastucture.Identity.Seeds
{
    public static class DefaultClient
    {
        public static async Task SeedAsync(UserManager<WorkSynergyUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            WorkSynergyUser defaultUser = new();
            defaultUser.UserName = "defaultContractor";
            defaultUser.Email = "defaultcontractor@gmail.com";
            defaultUser.FirstName = "Default";
            defaultUser.LastName = "Contractor";
            defaultUser.EmailConfirmed = true;
            defaultUser.PhoneNumberConfirmed = true;
            defaultUser.IsActive = true;
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, nameof(UserRoles.Client));
                }
            }

        }
    }
}
