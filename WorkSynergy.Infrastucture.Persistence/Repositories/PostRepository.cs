using Microsoft.EntityFrameworkCore;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Domain.Models;
using WorkSynergy.Infrastucture.Persistence.Contexts;

namespace WorkSynergy.Infrastucture.Persistence.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(ApplicationContext context) : base(context)
        {

        }
        public virtual async Task<Post> GetByIdWithIncludeAsync(int id, List<string> properties)
        {
            var query = _dbSet.AsQueryable();
            foreach (var property in properties)
            {
                query = query.Include(property);
            }
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
