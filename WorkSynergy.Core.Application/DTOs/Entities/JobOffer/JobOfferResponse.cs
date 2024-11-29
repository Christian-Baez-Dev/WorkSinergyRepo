using WorkSynergy.Core.Application.Dtos.Account;
using WorkSynergy.Core.Application.DTOs.Entities.ContractOption;
using WorkSynergy.Core.Application.DTOs.Entities.Currency;
using WorkSynergy.Core.Application.DTOs.Entities.Post;

namespace WorkSynergy.Core.Application.DTOs.Entities.JobOffer
{
    public class JobOfferResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateOnly StartDate { get; set; } //fecha de inicio
        public DateOnly EndDate { get; set; }  // fecha de cierre
        public double HourlyRate { get; set; } // promedio de money por horas\
        public string Status { get; set; }
        public string ClientUserId { get; set; }
        public UserDTO Client {  get; set; }
        public string FreelancerId { get; set; }
        public UserDTO Freelancer { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public int PostId { get; set; }
        public PostResponse? Post { get; set; }
        public int CurrencyId { get; set; }
        public CurrencyResponse? Currency { get; set; }
        public int ContractOptionId { get; set; }
        public ContractOptionResponse? ContractOption { get; set; }
    }
}
