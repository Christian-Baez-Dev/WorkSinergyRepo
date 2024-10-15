using WorkSynergy.Core.Domain.Common;

namespace WorkSynergy.Core.Domain.Models
{
    public class JobRating : BaseEntity
    {
        public string ApplicantId { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int Rate { get; set; }
    }
}
