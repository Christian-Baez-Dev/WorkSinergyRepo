﻿using WorkSynergy.Core.Domain.Common;

namespace WorkSynergy.Core.Domain.Models
{
    public class Post : BaseEntity
    {
        public string Description { get; set; }
        public string Currency { get; set; }
        public string Title { get; set; }
        public string PaymentMethod { get; set; }
        public string Category { get; set; }
        public string CreatorUserId { get; set; }

        public ICollection<JobApplications> Applications { get; set; }
        public ICollection<JobRating> Ratings { get; set; }
        public ICollection<PostTags> Tags { get; set; }

    }
}
