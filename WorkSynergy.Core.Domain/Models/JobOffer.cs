using WorkSynergy.Core.Domain.Common;

namespace WorkSynergy.Core.Domain.Models
{
    public class JobOffer : BaseEntity
    {
        public string Description { get; set; }
        public string Currency { get; set; }
        public string Title { get; set; }
        public string ContractOption { get; set; } //opcion de contrato
        public DateTime StartDate { get; set; } //fecha de inicio
        public DateTime EndDate { get; set; }  // fecha de cierre
        public double HourlyRate { get; set; } // promedio de money por horas
        public string ClientUserId { get; set; }
        public string FreelancerUserId { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
