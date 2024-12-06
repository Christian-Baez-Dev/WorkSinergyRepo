namespace WorkSynergy.Core.Application.DTOs.Entities.HourlyMilestone
{
    public class HourlyMilestonResponse
    {
        public int Id { get; set; }
        public int TotalHours { get; set; }
        public int CurrentHours { get; set; }
        public List<string>? Deliverables { get; set; }
    }
}
