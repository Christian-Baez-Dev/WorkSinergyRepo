using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSynergy.Core.Domain.Models
{
    public class Contract
    {
        public string Description { get; set; }
        public string Currency { get; set; }
        public long TotalPayment { get; set; }
        public long CurrentPayment { get; set; }
        public string Title { get; set; }
        public ContractOption ContractOption { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FreelancerId { get; set; }
        public string CreatorUserId { get; set; }
    }
}
