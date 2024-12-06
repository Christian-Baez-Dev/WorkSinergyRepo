using WorkSynergy.Core.Application.Dtos.Account;
using WorkSynergy.Core.Application.DTOs.Entities.ContractOption;
using WorkSynergy.Core.Application.DTOs.Entities.Currency;
using WorkSynergy.Core.Application.DTOs.Entities.FixedPriceMilestone;
using WorkSynergy.Core.Application.DTOs.Entities.HourlyMilestone;
using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Core.Application.DTOs.Entities.Contract
{
    public class ContractResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int CurrencyId { get; set; }
        public CurrencyResponse? Currency { get; set; }
        public long TotalPayment { get; set; }
        public long CurrentPayment { get; set; }
        public string Title { get; set; }
        public int ContractOptionId { get; set; }
        public ContractOptionResponse? ContractOption { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string FreelancerId { get; set; }
        public UserDTO? Freelancer { get; set; }
        public string CreatorUserId { get; set; }
        public UserDTO? CreatorUser { get; set; }
        public ICollection<FixedPriceMilestoneResponse>? FixedPriceMilestones { get; set; }
        public ICollection<HourlyMilestonResponse>? HourlyMilestones { get; set; }
    }
}
