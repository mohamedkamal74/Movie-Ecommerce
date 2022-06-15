using Microsoft.EntityFrameworkCore;
using Movie.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Ecommerce.Data.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class ,IEntityBase, new()
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
           _context = context;
        }
        public async Task AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

            _context.Set<T>().Remove(result);

            await _context.SaveChangesAsync();
        }

        public  IEnumerable<T> GetAll()
        {
            var result = _context.Set<T>().ToList();
            return result;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
