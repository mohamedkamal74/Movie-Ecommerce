using Microsoft.AspNetCore.Mvc;
using Movie.Data;
using Movie_Ecommerce.Data.Services;
using System.Linq;

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
    }
}
