using WorkSynergy.Core.Domain.Common;

namespace WorkSynergy.Core.Domain.Models
{
    public class Chat : BaseEntity
    {
        public int ClientId { get; set; }
        public int FreelancerId { get; set; }

    }
}
