using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Domain.Models;
using WorkSynergy.Infrastucture.Persistence.Contexts;

namespace WorkSynergy.Infrastucture.Persistence.Repositories
{
    public class AbilityRepository : GenericRepository<Ability>, IAbilityRepository
    {
        public AbilityRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
