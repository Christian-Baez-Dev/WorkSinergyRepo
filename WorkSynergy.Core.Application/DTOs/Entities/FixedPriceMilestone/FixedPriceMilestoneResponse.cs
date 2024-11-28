namespace WorkSynergy.Core.Application.DTOs.Entities.FixedPriceMilestone
{
    public class FixedPriceMilestoneResponse
    {
        public string? FilePath { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
