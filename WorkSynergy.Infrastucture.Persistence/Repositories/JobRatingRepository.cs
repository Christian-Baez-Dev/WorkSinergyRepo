using Microsoft.EntityFrameworkCore;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Domain.Models;
using WorkSynergy.Infrastucture.Persistence.Contexts;

namespace WorkSynergy.Infrastucture.Persistence.Repositories
{
    public class JobRatingRepository : GenericRepository<JobRating>, IJobRatingRepository
    {
        public JobRatingRepository(ApplicationContext context, DbSet<JobRating> dbSet) : base(context, dbSet)
        {
        }
    }
}
