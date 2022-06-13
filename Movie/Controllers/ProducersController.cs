using Microsoft.AspNetCore.Mvc;
using Movie.Data;
using System.Linq;

namespace Movie_Ecommerce.Controllers
{
    public class ProducersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProducersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Producers.ToList());
        }
    }
}
