using WorkSynergy.Core.Domain.Common;

namespace WorkSynergy.Core.Domain.Models
{
    public class ContractOption : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
