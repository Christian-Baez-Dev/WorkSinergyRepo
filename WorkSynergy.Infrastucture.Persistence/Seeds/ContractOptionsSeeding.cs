﻿using Microsoft.AspNetCore.Identity;
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
    public static class ContractOptionsSeeding
    {

        public static async Task SeedAsync(ApplicationContext context)
        {
            if (context.ContractOptions.Count() == 0)
            {

                var contractOptions = new List<ContractOption>
                {
                    new ContractOption { Name = nameof(ContractOptions.FixedPrice) },
                    new ContractOption { Name = nameof(ContractOptions.PerHour) }
                };

                context.ContractOptions.AddRange(contractOptions);
                await context.SaveChangesAsync();
            }
        }

    }
}
