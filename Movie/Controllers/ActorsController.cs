using Microsoft.AspNetCore.Mvc;
using Movie.Data;
using Movie.Models;
using Movie_Ecommerce.Data.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Ecommerce.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Actor actor)
        {
            if (ModelState.IsValid)
            {
                _service.Add(actor);
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }
    }
}
