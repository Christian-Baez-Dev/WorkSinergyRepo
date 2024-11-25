using WorkSynergy.Core.Domain.Common;

namespace WorkSynergy.Core.Domain.Models
{
    public class Ability : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<UserAbility>? Users { get; set; }
        public ICollection<PostAbility>? Posts { get; set; }
    }
}
