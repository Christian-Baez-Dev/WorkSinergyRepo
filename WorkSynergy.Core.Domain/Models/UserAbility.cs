using WorkSynergy.Core.Domain.Common;

namespace WorkSynergy.Core.Domain.Models
{
    public class UserAbility : BaseEntity
    {
        public string UserId { get; set; }
        public int AbilityId { get; set; }
        public Ability Ability { get; set; }
    }
}
