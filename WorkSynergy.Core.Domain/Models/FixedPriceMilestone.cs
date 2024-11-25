using WorkSynergy.Core.Domain.Common;

namespace WorkSynergy.Core.Domain.Models
{
    public class FixedPriceMilestone : BaseEntity
    {
        public string FilePath { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ContractId { get; set; }
        public Contract? Contract { get; set; }
    }
}
