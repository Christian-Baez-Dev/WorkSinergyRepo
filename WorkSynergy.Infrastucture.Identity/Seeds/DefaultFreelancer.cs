using Microsoft.AspNetCore.Identity;
using WorkSynergy.Core.Application.Enums;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Domain.Models;
using WorkSynergy.Infrastucture.Identity.Models;
using WorkSynergy.Infrastucture.Persistence.Contexts;

namespace WorkSynergy.Infrastucture.Identity.Seeds
{
    public static class DefaultFreelancer
    {
        public static async Task SeedAsync(UserManager<WorkSynergyUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationContext applicationContext)
        {
            WorkSynergyUser defaultUser = new();
            defaultUser.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer eleifend enim id volutpat efficitur. Praesent egestas leo aliquet eros eleifend, quis lobortis dui dignissim. Quisque facilisis aliquet enim sit amet laoreet. Praesent tempor, massa vitae condimentum hendrerit, augue eros aliquam lacus, sit amet suscipit neque nibh sit amet magna. Phasellus tristique tempor interdum. Nullam rhoncus tellus eu nisl luctus molestie. Suspendisse vel sem id quam elementum dignissim ut porttitor nunc. Proin consectetur quis nisl at varius. Cras suscipit varius dolor non gravida. Aliquam vel pretium lorem. Aenean dui urna, tristique in volutpat ac, gravida nec ligula. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Duis augue quam, facilisis non condimentum a, luctus sollicitudin libero. Aliquam aliquam diam a diam eleifend varius. Duis at libero tellus. Ut eget ipsum sem.";
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
                    await userManager.AddToRoleAsync(defaultUser, nameof(UserRoles.Freelancer));
                    await applicationContext.UserAbilities.AddRangeAsync(new List<UserAbility>()
                    {
                        new UserAbility(){ AbilityId = 1, UserId = defaultUser.Id},
                        new UserAbility(){ AbilityId = 3, UserId = defaultUser.Id},
                        new UserAbility(){ AbilityId = 6, UserId = defaultUser.Id},
                        new UserAbility(){ AbilityId = 8, UserId = defaultUser.Id},
                        new UserAbility(){ AbilityId = 2, UserId = defaultUser.Id},

                    });
                    applicationContext.SaveChanges();

                }
            }


        }
    }
}
