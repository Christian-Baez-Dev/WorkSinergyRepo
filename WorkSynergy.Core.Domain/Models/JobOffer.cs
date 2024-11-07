using WorkSynergy.Core.Domain.Common;

namespace WorkSynergy.Core.Domain.Models
{
    public class JobOffer : BaseEntity
    {
        public string Description { get; set; }
        public string Currency { get; set; }
        public string Title { get; set; }
        public string PaymentType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double HourlyRate { get; set; }
        public string ClientUserId { get; set; }
        public string FreelancerUserId { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
