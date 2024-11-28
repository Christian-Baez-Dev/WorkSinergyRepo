using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Domain.Models;
using WorkSynergy.Infrastucture.Persistence.Contexts;

namespace WorkSynergy.Infrastucture.Persistence.Repositories
{
    public class FixedPriceMilestoneRepository : GenericRepository<FixedPriceMilestone>, IFixedPriceMilestoneRepository
    {
        public FixedPriceMilestoneRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
