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
        Task<Actor> UpdateAsync(int id,Actor NewActor);
        Task Delete(int id);    
    }
}
