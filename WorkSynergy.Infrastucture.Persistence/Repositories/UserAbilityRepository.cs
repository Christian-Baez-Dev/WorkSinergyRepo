using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Domain.Models;
using WorkSynergy.Infrastucture.Persistence.Contexts;

namespace WorkSynergy.Infrastucture.Persistence.Repositories
{
    public class UserAbilityRepository : GenericRepository<UserAbility>, IUserAbilityRepository
    {
        public UserAbilityRepository(ApplicationContext context) : base(context)
        {
        }

 
    }
}
