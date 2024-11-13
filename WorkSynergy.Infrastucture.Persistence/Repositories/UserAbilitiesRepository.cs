using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Domain.Models;
using WorkSynergy.Infrastucture.Persistence.Contexts;

namespace WorkSynergy.Infrastucture.Persistence.Repositories
{
    public class UserAbilitiesRepository : GenericRepository<UserAbilities>, IUserAbilitiesRepository
    {
        public UserAbilitiesRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
