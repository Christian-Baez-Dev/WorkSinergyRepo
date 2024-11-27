using WorkSynergy.Core.Domain.Common;

namespace WorkSynergy.Core.Domain.Models
{
    public class JobOffer : BaseEntity
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; } //fecha de inicio
        public DateTime EndDate { get; set; }  // fecha de cierre
        public double HourlyRate { get; set; } // promedio de money por horas
        public string ClientUserId { get; set; }
        public string FreelancerId { get; set; }
        public string Status { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int PostId { get; set; }
        public Post? Post { get; set; }
        public int CurrencyId { get; set; }
        public Currency? Currency { get; set; }
        public int ContractOptionId { get; set; }
        public ContractOption? ContractOption { get; set; }

    }
}
