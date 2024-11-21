namespace WorkSynergy.Core.Domain.Models
{
    public class FixedPriceMilestone
    {
        public string FilePath { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ContractId { get; set; }
        public Contract Contract { get; set; }
    }
}
