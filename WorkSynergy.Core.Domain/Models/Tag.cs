using WorkSynergy.Core.Domain.Common;

namespace WorkSynergy.Core.Domain.Models
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<PostTag>? Posts { get; set; }
    }
}
