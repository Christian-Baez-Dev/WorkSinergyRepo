using WorkSynergy.Core.Domain.Common;

namespace WorkSynergy.Core.Domain.Models
{
    public class HourlyMilestoneDeliverable : BaseEntity
    {
        public string FilePath { get; set; }
        public int HourlyMilestoneId { get; set; }
        public HourlyMilestone HourlyMilestone { get; set; }

    }
}
