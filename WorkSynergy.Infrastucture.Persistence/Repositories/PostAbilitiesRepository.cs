using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Domain.Models;
using WorkSynergy.Infrastucture.Persistence.Contexts;

namespace WorkSynergy.Infrastucture.Persistence.Repositories
{
    public class PostAbilitiesRepository : GenericRepository<PostAbilities>, IPostAbilitiesRepository
    {
        public PostAbilitiesRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
