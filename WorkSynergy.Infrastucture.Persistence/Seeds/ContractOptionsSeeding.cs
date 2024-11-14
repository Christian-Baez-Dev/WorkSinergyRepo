using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSynergy.Core.Application.Enums;
using WorkSynergy.Infrastucture.Persistence.Contexts;

namespace WorkSynergy.Infrastucture.Persistence.Seeds
{
    public static class ContractOptionsSeeding
    {

        public static async Task SeedAsync(ApplicationContext context)
        {
            context.ContractOptions.Add(new Core.Domain.Models.ContractOption { Id = (int)ContractOptions.FixedPrice, Name = nameof(ContractOptions.FixedPrice)});
            context.ContractOptions.Add(new Core.Domain.Models.ContractOption { Id = (int)ContractOptions.PerHour, Name = nameof(ContractOptions.PerHour) });
            await context.SaveChangesAsync();
        }

    }
}
