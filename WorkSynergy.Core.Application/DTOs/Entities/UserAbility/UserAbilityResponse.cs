using WorkSynergy.Core.Application.DTOs.Entities.Ability;

namespace WorkSynergy.Core.Application.DTOs.Entities.UserAbility
{
    public class UserAbilityResponse
    {
        public AbilityResponse Ability {  get; set; }
        public string UserId {  get; set; }
    }
}
