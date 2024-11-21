using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using WorkSynergy.Core.Application.Interfaces.Repositories;
using WorkSynergy.Core.Domain.Common;
using WorkSynergy.Infrastucture.Persistence.Contexts;

namespace WorkSynergy.Infrastucture.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity
    {
        protected readonly ApplicationContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();  
        }
        public async Task<(List<T> Result, int TotalCount,
            int TotalPages, bool HasPrevious, bool HasNext)>
            GetAllOrderAndPaginateAsync(Expression<Func<T, bool>> searchPredicate = null,
            Expression<Func<T, object>> orderBy = null,
            bool isDescending = false,
            int? pageNumber = null,
            int? pageSize = null,
            params Expression<Func<T, object>>[] properties)
        {
            IQueryable<T> query = _dbSet;
            if(searchPredicate != null)
                query = query.Where(searchPredicate);
            if(orderBy != null && !isDescending)
                query = query.OrderBy(orderBy);
            if (orderBy != null && isDescending)
                query = query.OrderByDescending(orderBy);

            foreach (var property in properties)
            {
                query = query.Include(property);
            }
            int totalNumber = await _dbSet.CountAsync();

            if ((pageNumber.HasValue && pageNumber > 0) && (pageSize.HasValue && pageSize > 0))
            {
                query = query.Skip((pageNumber.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }
            int? totalPages = (pageNumber.HasValue && pageNumber > 0) && (pageSize.HasValue && pageSize > 0)
                ? (int?)Math.Ceiling((double)totalNumber / pageSize.Value)
                : null;
            bool? hasPrevious = pageNumber.HasValue ? pageNumber > 1 : null;
            bool? hasNext = pageNumber.HasValue ? pageNumber < totalPages : null;
            var result = await query.ToListAsync();
            return (result, totalNumber, totalPages ?? 0, hasPrevious ?? false, hasNext ?? false );
        }
        public async Task<List<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task<List<T>> GetAllAsync(int skip, int count) => await _dbSet.Skip((skip - 1) * count).Take(count).ToListAsync();

        public async Task<List<T>> GetAllWithIncludeAsync(params Expression<Func<T, object>>[] properties )
        {
            var query = _dbSet.AsQueryable();
            foreach (var property in properties)
            {
                query = query.Include(property);
            }
            return await query.ToListAsync();
        }
        public async Task<T> GetByIdIncludeAsync(int id, params Expression<Func<T, object>>[] properties)
        {
            var query = _dbSet.AsQueryable();
            foreach (var property in properties)
            {
                query = query.Include(property);
            }
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> match) => await _dbSet.Where(match).ToListAsync();
        public async Task<T> FindAsync(Expression<Func<T, bool>> match) => await _dbSet.FirstOrDefaultAsync(match);

        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task<T> UpdateAsync(T entity, int id)
        {
            try
            {
                var entry = await _context.Set<T>().FindAsync(id);
                _context.Entry(entry).CurrentValues.SetValues(entity);
                _context.Entry(entry).Property(x => x.CreatedAt).IsModified = false;
                _context.Entry(entry).Property(x => x.IsDeleted).IsModified = false;
                _context.Entry(entry).Property(x => x.DeletedAt).IsModified = false;


                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
