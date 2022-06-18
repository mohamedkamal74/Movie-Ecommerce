using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Movie.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Movie_Ecommerce.Data.Base
{
    //public class BaseRepository<T> : IBaseRepository<T> where T : class ,IEntityBase, new()
    //{
    //    private readonly ApplicationDbContext _context;

    //    public BaseRepository(ApplicationDbContext context)
    //    {
    //       _context = context;
    //    }
    //    public async Task AddAsync(T entity)
    //    {
    //        _context.Set<T>().Add(entity);

    //    }

    //    public async Task Delete(int id)
    //    {
    //        var entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    //        EntityEntry entityEntry = _context.Entry<T>(entity);
    //        entityEntry.State = EntityState.Deleted;


    //    }

    //    public  IEnumerable<T> GetAll()
    //    {
    //        var result = _context.Set<T>().ToList();
    //        return result;
    //    }

    //    public async Task<T> GetByIdAsync(int id)
    //    {
    //        var result = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    //        return result;
    //    }

    //    public async Task UpdateAsync(int id, T entity)
    //    {
    //       EntityEntry entityEntry = _context.Entry<T>(entity);
    //        entityEntry.State = EntityState.Modified;

    //    }
    //}


    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();

        }

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
