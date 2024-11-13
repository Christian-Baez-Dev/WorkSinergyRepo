using WorkSynergy.Core.Domain.Common;

namespace WorkSynergy.Core.Domain.Models
{
    public class PostAbilities : BaseEntity
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int AbilityId { get; set; }
        public Ability Ability { get; set; }
    }
}
