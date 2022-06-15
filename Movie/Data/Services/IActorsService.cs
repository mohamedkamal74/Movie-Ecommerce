using Movie.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie_Ecommerce.Data.Services
{
    public interface IActorsService
    {
        IEnumerable<Actor> GetAll();
       Task<Actor> GetByIdAsync(int id);
        Task AddAsync(Actor actor);
        Task UpdateAsync(int id,Actor NewActor);
        void Delete(int id);    
    }
}
