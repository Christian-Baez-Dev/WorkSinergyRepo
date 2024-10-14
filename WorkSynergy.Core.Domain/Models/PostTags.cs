using WorkSynergy.Core.Domain.Common;

namespace WorkSynergy.Core.Domain.Models
{
    public class PostTags : BaseEntity
    {
        public int JobId { get; set; }
        public int TagId { get; set; }
    }
}
