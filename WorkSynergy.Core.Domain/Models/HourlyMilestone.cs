using WorkSynergy.Core.Domain.Common;

namespace WorkSynergy.Core.Domain.Models
{
    public class HourlyMilestone : BaseEntity
    {
        public int TotalHours { get; set; }
        public int CurrentHours { get; set; }
        public int ContractId { get; set; }
        public Contract Contract { get; set; }
    }
}
