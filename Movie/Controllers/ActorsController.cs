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
               await _service.AddAsync(actor);
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        public async Task< IActionResult> Details(int id)
        {
            
            var ActorDetails =await _service.GetByIdAsync(id);
            if(ActorDetails == null)
            {
                return NotFound();
            }
            return View(ActorDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {

            var ActorDetails = await _service.GetByIdAsync(id);
            if (ActorDetails == null)
            {
                return NotFound();
            }
            return View(ActorDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Actor actor)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(id,actor);
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        public async Task<IActionResult> Delete(int id)
        {

            var ActorDetails = await _service.GetByIdAsync(id);
            if (ActorDetails == null)
            {
                return NotFound();
            }
            return View(ActorDetails);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {

            var ActorDetails = await _service.GetByIdAsync(id);
            if (ActorDetails == null)
            {
                return NotFound();
            }
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
