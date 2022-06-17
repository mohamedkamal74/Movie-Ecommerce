using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie.Data;
using System.Linq;

namespace Movie_Ecommerce.Controllers
{
    public class MoviesController : Controller
    {
        //private readonly ApplicationDbContext _context;

        //public MoviesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        //public IActionResult Index()
        //{
        //    return View(_context.Movies.Include(c=>c.Cinema).OrderBy(n=>n.Name).ToList());
        //}
    }
}
