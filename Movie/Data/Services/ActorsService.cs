using Microsoft.EntityFrameworkCore;
using Movie.Data;
using Movie.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Ecommerce.Data.Services
{
   
    public class ActorsService : IActorsService
    {
        private readonly ApplicationDbContext _context;

        public ActorsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Actor actor)
        {
           _context.Actors.Add(actor);
           await _context.SaveChangesAsync();
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

        public async Task<Actor> GetByIdAsync(int id)
        {
            var result=await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public void Update(int id, Actor NewActor)
        {
            throw new System.NotImplementedException();
        }

       
    }
}
