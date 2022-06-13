using Microsoft.AspNetCore.Mvc;
using Movie.Data;
using System.Linq;

namespace Movie_Ecommerce.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CinemasController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Cinemas.ToList());
        }
    }
}
