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
    public static class CurrencySeeding
    {

        public static async Task SeedAsync(ApplicationContext context)
        {
            if (context.Currencies.Count() == 0)
            {

                var currencies = new List<Currency>
                {
                    new Currency { Name = "US Dollar", Iso3Code = "USD" },
                    new Currency { Name = "Dominican Peso", Iso3Code = "DOP" }
                };

                context.Currencies.AddRange(currencies);
                await context.SaveChangesAsync();
            }
        }

    }
}
