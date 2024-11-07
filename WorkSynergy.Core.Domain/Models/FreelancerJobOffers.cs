using WorkSynergy.Core.Domain.Common;

namespace WorkSynergy.Core.Domain.Models
{
    public class FreelancerJobOffers : BaseEntity
    {
        public string ApplicantId { get; set; }
        public int JobOfferId { get; set; }
        public JobOffer JobOffer { get; set; }
        public bool IsAcepted { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
