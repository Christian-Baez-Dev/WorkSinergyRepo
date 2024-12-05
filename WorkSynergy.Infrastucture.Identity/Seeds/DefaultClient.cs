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
            List<WorkSynergyUser> users = new List<WorkSynergyUser>()
            {
               new WorkSynergyUser
               {
                   Id = "client1-id",
                   UserName = "defaultClient1",
                   Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer eleifend enim id volutpat efficitur. Praesent egestas leo aliquet eros eleifend, quis lobortis dui dignissim. Quisque facilisis aliquet enim sit amet laoreet. Praesent tempor, massa vitae condimentum hendrerit, augue eros aliquam lacus, sit amet suscipit neque nibh sit amet magna. Phasellus tristique tempor interdum. Nullam rhoncus tellus eu nisl luctus molestie. Suspendisse vel sem id quam elementum dignissim ut porttitor nunc. Proin consectetur quis nisl at varius. Cras suscipit varius dolor non gravida. Aliquam vel pretium lorem. Aenean dui urna, tristique in volutpat ac, gravida nec ligula. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Duis augue quam, facilisis non condimentum a, luctus sollicitudin libero. Aliquam aliquam diam a diam eleifend varius. Duis at libero tellus. Ut eget ipsum sem.",
                   Email = "defaultclient1@gmail.com",
                   FirstName = "Default",
                   LastName = "Client 1",
                   EmailConfirmed = true,
                   PhoneNumberConfirmed = true,
                   IsActive = true,
               },
               new WorkSynergyUser
               {
                   Id = "client2-id",
                   UserName = "defaultClient2",
                   Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer eleifend enim id volutpat efficitur. Praesent egestas leo aliquet eros eleifend, quis lobortis dui dignissim. Quisque facilisis aliquet enim sit amet laoreet. Praesent tempor, massa vitae condimentum hendrerit, augue eros aliquam lacus, sit amet suscipit neque nibh sit amet magna. Phasellus tristique tempor interdum. Nullam rhoncus tellus eu nisl luctus molestie. Suspendisse vel sem id quam elementum dignissim ut porttitor nunc. Proin consectetur quis nisl at varius. Cras suscipit varius dolor non gravida. Aliquam vel pretium lorem. Aenean dui urna, tristique in volutpat ac, gravida nec ligula. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Duis augue quam, facilisis non condimentum a, luctus sollicitudin libero. Aliquam aliquam diam a diam eleifend varius. Duis at libero tellus. Ut eget ipsum sem.",
                   Email = "defaultclient2@gmail.com",
                   FirstName = "Default",
                   LastName = "Client 2",
                   EmailConfirmed = true,
                   PhoneNumberConfirmed = true,
                   IsActive = true,
               },
               new WorkSynergyUser
               {
                   Id = "client3-id",
                   UserName = "defaultClient3",
                   Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer eleifend enim id volutpat efficitur. Praesent egestas leo aliquet eros eleifend, quis lobortis dui dignissim. Quisque facilisis aliquet enim sit amet laoreet. Praesent tempor, massa vitae condimentum hendrerit, augue eros aliquam lacus, sit amet suscipit neque nibh sit amet magna. Phasellus tristique tempor interdum. Nullam rhoncus tellus eu nisl luctus molestie. Suspendisse vel sem id quam elementum dignissim ut porttitor nunc. Proin consectetur quis nisl at varius. Cras suscipit varius dolor non gravida. Aliquam vel pretium lorem. Aenean dui urna, tristique in volutpat ac, gravida nec ligula. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Duis augue quam, facilisis non condimentum a, luctus sollicitudin libero. Aliquam aliquam diam a diam eleifend varius. Duis at libero tellus. Ut eget ipsum sem.",
                   Email = "defaultclient3@gmail.com",
                   FirstName = "Default",
                   LastName = "Client 3",
                   EmailConfirmed = true,
                   PhoneNumberConfirmed = true,
                   IsActive = true,
               },
               new WorkSynergyUser
               {
                   Id = "client4-id",
                   UserName = "defaultClient4",
                   Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer eleifend enim id volutpat efficitur. Praesent egestas leo aliquet eros eleifend, quis lobortis dui dignissim. Quisque facilisis aliquet enim sit amet laoreet. Praesent tempor, massa vitae condimentum hendrerit, augue eros aliquam lacus, sit amet suscipit neque nibh sit amet magna. Phasellus tristique tempor interdum. Nullam rhoncus tellus eu nisl luctus molestie. Suspendisse vel sem id quam elementum dignissim ut porttitor nunc. Proin consectetur quis nisl at varius. Cras suscipit varius dolor non gravida. Aliquam vel pretium lorem. Aenean dui urna, tristique in volutpat ac, gravida nec ligula. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Duis augue quam, facilisis non condimentum a, luctus sollicitudin libero. Aliquam aliquam diam a diam eleifend varius. Duis at libero tellus. Ut eget ipsum sem.",
                   Email = "defaultclient4@gmail.com",
                   FirstName = "Default",
                   LastName = "Client 4",
                   EmailConfirmed = true,
                   PhoneNumberConfirmed = true,
                   IsActive = true,
               }

            };

            foreach (var defaultUser in users)
            {
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
}
