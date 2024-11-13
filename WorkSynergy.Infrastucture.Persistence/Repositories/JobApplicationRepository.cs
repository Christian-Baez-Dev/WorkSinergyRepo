using Microsoft.EntityFrameworkCore;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Domain.Models;
using WorkSynergy.Infrastucture.Persistence.Contexts;

namespace WorkSynergy.Infrastucture.Persistence.Repositories
{
    public class JobApplicationRepository : GenericRepository<JobApplications>, IJobApplicationRepository
    {
        public JobApplicationRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
