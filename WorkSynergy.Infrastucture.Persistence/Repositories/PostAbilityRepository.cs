using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Domain.Models;
using WorkSynergy.Infrastucture.Persistence.Contexts;

namespace WorkSynergy.Infrastucture.Persistence.Repositories
{
    public class PostAbilityRepository : GenericRepository<PostAbility>, IPostAbilityRepository
    {
        public PostAbilityRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
