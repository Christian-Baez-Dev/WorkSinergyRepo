using Microsoft.EntityFrameworkCore;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Domain.Models;
using WorkSynergy.Infrastucture.Persistence.Contexts;

namespace WorkSynergy.Infrastucture.Persistence.Repositories
{
    public class PostTagRepository : GenericRepository<PostTag>, IPostTagRepository
    {
        public PostTagRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
