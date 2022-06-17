using Microsoft.AspNetCore.Mvc;
using Movie.Data;
using Movie.Models;
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
            return View(_context.Cinemas.OrderBy(n => n.Name).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                _context.Cinemas.Add(cinema);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cinema);
        }

        public IActionResult Edit(int id)
        {
           
            var cinemaupdate = _context.Cinemas.FirstOrDefault(x => x.Id == id);
            if (cinemaupdate == null)
            {
                return NotFound();
            }
            return View(cinemaupdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                _context.Cinemas.Update(cinema);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cinema);
        }

        public IActionResult Details(int id)
        {

            var cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            return View(cinema);
        }

        public IActionResult Delete(int id)
        {

            var cinemaupdate = _context.Cinemas.FirstOrDefault(x => x.Id == id);
            if (cinemaupdate == null)
            {
                return NotFound();
            }
            return View(cinemaupdate);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var cinemaupdate = _context.Cinemas.FirstOrDefault(x => x.Id == id);
            if (cinemaupdate == null)
            {
                return NotFound();
            }
          _context.Cinemas.Remove(cinemaupdate);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
