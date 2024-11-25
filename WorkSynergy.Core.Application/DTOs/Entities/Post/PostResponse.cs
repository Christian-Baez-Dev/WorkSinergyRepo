using WorkSynergy.Core.Application.DTOs.Entities.Ability;
using WorkSynergy.Core.Application.DTOs.Entities.ContractOption;
using WorkSynergy.Core.Application.DTOs.Entities.Currency;
using WorkSynergy.Core.Application.DTOs.Entities.Tag;

namespace WorkSynergy.Core.Application.DTOs.Entities.Post
{
    public class PostResponse
    {
        public int Id { get; set; } 
        public string Description { get; set; }
        public CurrencyResponse Currency { get; set; }
        public DateOnly CreatedAt { get; set; }
        public long From { get; set; }
        public long To { get; set; }
        public string Title { get; set; }
        public int ApplicationsCount { get; set; }
        public ContractOptionResponse ContractOption { get; set; }
        public IEnumerable<AbilityResponse> Abilities { get; set; }
        public IEnumerable<TagResponse> Tags { get; set; }


    }
}
