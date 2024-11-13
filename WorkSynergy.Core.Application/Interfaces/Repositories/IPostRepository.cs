using WorkSynergy.Core.Domain.Models;

namespace WorkSynergy.Core.Application.Interfaces.Repositories
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<Post> GetByIdWithIncludeAsync(int id, List<string> properties);

    }
}
