using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSynergy.Core.Application.DTOs.Entities.Currency
{
    public class CurrencyResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Iso3Code { get; set; }
    }
}
