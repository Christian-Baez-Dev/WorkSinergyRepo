using System.Linq.Expressions;

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
        Task<List<T>> GetAllWithIncludeAsync(params Expression<Func<T, object>>[] properties);

        Task<(List<T> Result, int TotalCount,
            int TotalPages, bool HasPrevious, bool HasNext)>
            GetAllOrderAndPaginateAsync(Expression<Func<T, bool>> searchPredicate = null,
            Expression<Func<T, object>> orderBy = null,
            bool isDescending = false,
            int? pageNumber = null,
            int? pageSize = null,
            params Expression<Func<T, object>>[] properties);

        Task<T> GetByIdIncludeAsync(int id, params Expression<Func<T, object>>[] properties);

        Task<List<T>> FindAllAsync(Expression<Func<T, bool>> match);

    }
}
