using WorkSynergy.Core.Domain.Common;

namespace WorkSynergy.Core.Domain.Models
{
    public class Ability : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<PostAbilities> Posts { get; set; }
        public ICollection<UserAbilities> Users { get; set; }
    }
}
