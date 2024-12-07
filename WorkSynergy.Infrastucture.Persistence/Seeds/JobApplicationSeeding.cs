using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSynergy.Core.Application.Enums;
using WorkSynergy.Core.Domain.Models;
using WorkSynergy.Infrastucture.Persistence.Contexts;

namespace WorkSynergy.Infrastucture.Persistence.Seeds
{
    public static class JobApplicationSeeding
    {

        public static async Task SeedAsync(ApplicationContext context)
        {
            if (context.JobApplications.Count() == 0)
            {

                var applications = new List<JobApplication>
                {
                    new JobApplication 
                    {
                        ApplicantId = "freelancer1-id",
                        Description = "Quiero aplicar a una oportunidad de trabajo en un area donde soy experto",
                        PostId = 1,
                        Status = nameof(AsynchronousStatus.Waiting),
                    },
                    new JobApplication
                    {
                        ApplicantId = "freelancer2-id",
                        Description = "Quiero aplicar a una oportunidad de trabajo en un area donde soy experto",
                        PostId = 1,
                        Status = nameof(AsynchronousStatus.Waiting),
                    },
                    new JobApplication
                    {
                        ApplicantId = "freelancer3-id",
                        Description = "Quiero aplicar a una oportunidad de trabajo en un area donde soy experto",
                        PostId = 1,
                        Status = nameof(AsynchronousStatus.Waiting),
                    },
                    new JobApplication
                    {
                        ApplicantId = "freelancer1-id",
                        Description = "Quiero aplicar a una oportunidad de trabajo en un area donde soy experto",
                        PostId = 2,
                        Status = nameof(AsynchronousStatus.Waiting),
                    },
                    new JobApplication
                    {
                        ApplicantId = "freelancer4-id",
                        Description = "Quiero aplicar a una oportunidad de trabajo en un area donde soy experto",
                        PostId = 2,
                        Status = nameof(AsynchronousStatus.Waiting),
                    },
                    new JobApplication
                    {
                        ApplicantId = "freelancer2-id",
                        Description = "Quiero aplicar a una oportunidad de trabajo en un area donde soy experto",
                        PostId = 3,
                        Status = nameof(AsynchronousStatus.Waiting),
                    },
                    new JobApplication
                    {
                        ApplicantId = "freelancer2-id",
                        Description = "Quiero aplicar a una oportunidad de trabajo en un area donde soy experto",
                        PostId = 4,
                        Status = nameof(AsynchronousStatus.Waiting),
                    },
                    new JobApplication
                    {
                        ApplicantId = "freelancer3-id",
                        Description = "Quiero aplicar a una oportunidad de trabajo en un area donde soy experto",
                        PostId = 5,
                        Status = nameof(AsynchronousStatus.Waiting),
                    },
                    new JobApplication
                    {
                        ApplicantId = "freelancer3-id",
                        Description = "Quiero aplicar a una oportunidad de trabajo en un area donde soy experto",
                        PostId = 6,
                        Status = nameof(AsynchronousStatus.Waiting),
                    },
                    new JobApplication
                    {
                        ApplicantId = "freelancer4-id",
                        Description = "Quiero aplicar a una oportunidad de trabajo en un area donde soy experto",
                        PostId = 7,
                        Status = nameof(AsynchronousStatus.Waiting),
                    },
                    new JobApplication
                    {
                        ApplicantId = "freelancer4-id",
                        Description = "Quiero aplicar a una oportunidad de trabajo en un area donde soy experto",
                        PostId = 8,
                        Status = nameof(AsynchronousStatus.Waiting),
                    },
                };
                try
                {

                    context.JobApplications.AddRange(applications);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                }
            }
        }

    }
}
