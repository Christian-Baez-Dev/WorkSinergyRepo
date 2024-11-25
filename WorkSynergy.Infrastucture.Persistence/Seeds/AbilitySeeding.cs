using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSynergy.Core.Application.Enums;
using WorkSynergy.Core.Domain.Models;
using WorkSynergy.Infrastucture.Persistence.Contexts;

namespace WorkSynergy.Infrastucture.Persistence.Seeds
{
    public static class AbilitySeeding
    {

        public static async Task SeedAsync(ApplicationContext context)
        {
            if (context.Abilities.Count() == 0)
            {

                var abilities = new List<Ability>
                {
                    new Ability {Name = "UX/UI" },
                    new Ability {Name = "C#" },
                    new Ability { Name = "Web Design" },
                    new Ability { Name = "TypeScript" },
                    new Ability { Name = "Angular" },
                    new Ability { Name = "React" },
                    new Ability { Name = "ASP.NET Core" },
                    new Ability { Name = "Machine Learning" },
                    new Ability { Name = "Database Management" },
                    new Ability { Name = "Java" },
                    new Ability { Name = "3D Design" },
                    new Ability { Name = "AWS" },
                    new Ability { Name = "Firebase" },
                    new Ability { Name = "VueJs" },
                    new Ability { Name = "NodeJs" },
                    new Ability { Name = "Spring" },
                    new Ability { Name = "SQL Server" },
                    new Ability { Name = "MongoDB" },
                    new Ability { Name = "PostgreSQL" },
                    new Ability { Name = "SQLite" }
                };
                try
                {

                    context.Abilities.AddRange(abilities);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                }
            }
        }

    }
}
