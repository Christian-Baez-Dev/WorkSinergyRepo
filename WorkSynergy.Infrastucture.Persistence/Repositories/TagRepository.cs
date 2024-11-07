using Microsoft.EntityFrameworkCore;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Domain.Models;
using WorkSynergy.Infrastucture.Persistence.Contexts;

namespace WorkSynergy.Infrastucture.Persistence.Repositories
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(ApplicationContext context, DbSet<Tag> dbSet) : base(context, dbSet)
        {
        }
    }
}
