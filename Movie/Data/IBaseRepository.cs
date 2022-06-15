using Movie_Ecommerce.Data.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie_Ecommerce.Data
{
    public interface IBaseRepository<T>where T : class,IEntityBase,new()
    {
        IEnumerable<T> GetAll();
       Task <T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task<T> UpdateAsync(int id, T entity);
        Task Delete(int id);
    }
}
