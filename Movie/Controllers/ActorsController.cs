using Microsoft.AspNetCore.Mvc;
using Movie.Data;
using System.Linq;

namespace Movie_Ecommerce.Controllers
{
    public class ActorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActorsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Actors.ToList());
        }
    }
}
