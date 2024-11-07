using Microsoft.EntityFrameworkCore;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Domain.Models;
using WorkSynergy.Infrastucture.Persistence.Contexts;

namespace WorkSynergy.Infrastucture.Persistence.Repositories
{
    public class PostTagsRepository : GenericRepository<PostTags>, IPostTagsRepository
    {
        public PostTagsRepository(ApplicationContext context, DbSet<PostTags> dbSet) : base(context, dbSet)
        {
        }
    }
}
