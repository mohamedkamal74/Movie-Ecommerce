using Movie.Models;
using System.Collections.Generic;

namespace Movie_Ecommerce.Data.Services
{
    public interface IActorsService
    {
        IEnumerable<Actor> GetAll();
        Actor GetById(int id);
        void Add(Actor actor);
        void Update(int id,Actor NewActor);
        void Delete(int id);    
    }
}
