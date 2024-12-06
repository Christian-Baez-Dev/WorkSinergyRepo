using WorkSynergy.Core.Domain.Common;

namespace WorkSynergy.Core.Domain.Models
{
    public class Contract : BaseEntity
    {
        public string Description { get; set; }
        public int CurrencyId { get; set; }
        public Currency? Currency { get; set; }
        public double TotalPayment { get; set; }
        public double CurrentPayment { get; set; }
        public string Title { get; set; }
        public int ContractOptionId { get; set; }
        public ContractOption? ContractOption { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FreelancerId { get; set; }
        public string CreatorUserId { get; set; }
        public ICollection<FixedPriceMilestone>? FixedPriceMilestones { get; set; }
        public ICollection<HourlyMilestone>? HourlyMilestones { get; set; }

    }
}
