using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Domain.Models;
using WorkSynergy.Infrastucture.Persistence.Contexts;

namespace WorkSynergy.Infrastucture.Persistence.Repositories
{
    public class HourlyMilestoneRepository : GenericRepository<HourlyMilestone>, IHourlyMilestoneRepository
    {
        public HourlyMilestoneRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
