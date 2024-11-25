using WorkSynergy.Core.Domain.Common;

namespace WorkSynergy.Core.Domain.Models
{
    public class Currency : BaseEntity
    {
        public string Name { get; set; }
        public string Iso3Code { get; set; }
        public ICollection<Contract>? Contracts { get; set; }
        public ICollection<JobOffer>? JobOffers { get; set; }
        public ICollection<Post>? Posts { get; set; }
    }
}
