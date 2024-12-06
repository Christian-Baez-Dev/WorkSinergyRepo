namespace WorkSynergy.Core.Application.DTOs.Entities.FixedPriceMilestone
{
    public class FixedPriceMilestoneResponse
    {
        public int Id { get; set; }
        public string? FilePath { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
