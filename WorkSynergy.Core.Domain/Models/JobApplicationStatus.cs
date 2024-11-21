using WorkSynergy.Core.Domain.Common;

namespace WorkSynergy.Core.Domain.Models
{
    public class JobApplicationStatus : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<JobApplication> JobApplications { get; set; }
    }
}
