﻿using WorkSynergy.Core.Domain.Common;

namespace WorkSynergy.Core.Domain.Models
{
    public class JobApplications : BaseEntity
    {
        public string ApplicantId { get; set; }
        public int JobId { get; set; }
        public string Status { get; set; }

    }
}
