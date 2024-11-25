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
    public static class TagSeeding
    {

        public static async Task SeedAsync(ApplicationContext context)
        {
            if (context.Tags.Count() == 0)
            {

                var tags = new List<Tag>
                {
                    new Tag { Name = "Web Development" },
                    new Tag { Name = "Backend Development" },
                    new Tag { Name = "Database Engineering" },
                    new Tag { Name = "Cloud Development" },
                    new Tag { Name = "Design" },
                    new Tag { Name = "Multimedia" },
                    new Tag { Name = "Frontend Development" },
                    new Tag { Name = "IA" },
                    new Tag { Name = "Data Science" },
                    new Tag { Name = "Full Stack Development" }
                };

                context.Tags.AddRange(tags);
                await context.SaveChangesAsync();
            }
        }

    }
}
