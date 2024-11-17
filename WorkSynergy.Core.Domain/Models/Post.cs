﻿using WorkSynergy.Core.Domain.Common;

namespace WorkSynergy.Core.Domain.Models
{
    public class Post : BaseEntity
    {
        public string Description { get; set; }
        public string Currency { get; set; }
        public string Title { get; set; }
        public string CreatorUserId { get; set; }
        //Aproximate budget
        public double From { get; set; }
        public double To { get; set; }
        public int ContractOptionId { get; set; }
        public ContractOption ContractOption { get; set; }
        public ICollection<JobApplication> Applications { get; set; }
        public ICollection<JobRating> Ratings { get; set; }
        public ICollection<PostTag> Tags { get; set; }
        public ICollection<PostAbility> Abilities { get; set; }


    }
}
