using WorkSynergy.Core.Domain.Common;

namespace WorkSynergy.Core.Domain.Models
{
    public class JobApplication : BaseEntity
    {
        public string ApplicantId { get; set; }
        public int PostId { get; set; }
        public Post? Post { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
