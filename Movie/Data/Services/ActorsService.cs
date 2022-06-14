using Movie.Data;
using Movie.Models;
using System.Collections.Generic;
using System.Linq;

namespace Movie_Ecommerce.Data.Services
{
   
    public class ActorsService : IActorsService
    {
        private readonly ApplicationDbContext _context;

        public ActorsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Actor actor)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Actor> GetAll()
        {
            var result = _context.Actors.ToList();
            return result;
        }

        public Actor GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, Actor NewActor)
        {
            throw new System.NotImplementedException();
        }
    }
}
