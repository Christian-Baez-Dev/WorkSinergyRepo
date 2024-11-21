using WorkSynergy.Core.Application.DTOs.Entities.Post;

namespace WorkSynergy.Core.Application.DTOs.Entities.JobApplication
{
    public class JobApplicationResponse
    {
        public int Id { get; set; } 
        public string Description { get; set; }
        public string ApplicantId { get; set; }
        public PostResponse Post { get; set; }
    }
}
