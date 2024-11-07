using Microsoft.EntityFrameworkCore;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Domain.Models;
using WorkSynergy.Infrastucture.Persistence.Contexts;

namespace WorkSynergy.Infrastucture.Persistence.Repositories
{
    public class JobOfferRepository : GenericRepository<JobOffer>, IJobOfferRepository
    {
        public JobOfferRepository(ApplicationContext context, DbSet<JobOffer> dbSet) : base(context, dbSet)
        {
        }
    }
}
