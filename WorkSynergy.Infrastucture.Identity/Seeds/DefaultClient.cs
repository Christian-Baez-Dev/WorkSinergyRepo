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
            defaultUser.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer eleifend enim id volutpat efficitur. Praesent egestas leo aliquet eros eleifend, quis lobortis dui dignissim. Quisque facilisis aliquet enim sit amet laoreet. Praesent tempor, massa vitae condimentum hendrerit, augue eros aliquam lacus, sit amet suscipit neque nibh sit amet magna. Phasellus tristique tempor interdum. Nullam rhoncus tellus eu nisl luctus molestie. Suspendisse vel sem id quam elementum dignissim ut porttitor nunc. Proin consectetur quis nisl at varius. Cras suscipit varius dolor non gravida. Aliquam vel pretium lorem. Aenean dui urna, tristique in volutpat ac, gravida nec ligula. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Duis augue quam, facilisis non condimentum a, luctus sollicitudin libero. Aliquam aliquam diam a diam eleifend varius. Duis at libero tellus. Ut eget ipsum sem.";
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
