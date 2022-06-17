using Microsoft.AspNetCore.Mvc;
using Movie.Data;
using Movie.Models;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producer model)
        {
            if (ModelState.IsValid)
            {
                _context.Producers.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {

            var Producerupdate = _context.Producers.FirstOrDefault(x => x.Id == id);
            if (Producerupdate == null)
            {
                return NotFound();
            }
            return View(Producerupdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Producer model)
        {
            if (ModelState.IsValid)
            {
                _context.Producers.Update(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Details(int id)
        {

            var producer = _context.Producers.FirstOrDefault(x => x.Id == id);
            if (producer == null)
            {
                return NotFound();
            }
            return View(producer);
        }

        public IActionResult Delete(int id)
        {

            var producer = _context.Producers.FirstOrDefault(x => x.Id == id);
            if (producer == null)
            {
                return NotFound();
            }
            return View(producer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var producer = _context.Producers.FirstOrDefault(x => x.Id == id);
            if (producer == null)
            {
                return NotFound();
            }
            _context.Producers.Remove(producer);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
