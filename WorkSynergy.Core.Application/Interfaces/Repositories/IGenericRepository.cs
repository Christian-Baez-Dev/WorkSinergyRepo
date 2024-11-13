namespace WorkSynergy.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T>
        where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity, int id);
        Task DeleteAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(int skip, int count);
        Task<List<T>> GetAllWithIncludeAsync(List<string> properties);
    }
}
