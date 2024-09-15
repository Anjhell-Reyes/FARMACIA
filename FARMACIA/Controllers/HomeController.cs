using FARMACIA.Models;
using FARMACIA.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FARMACIA.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorioFarmacia repositorioFarmacia;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IRepositorioFarmacia repositorioFarmacia)
        {
            _logger = logger;
            this.repositorioFarmacia = repositorioFarmacia;
        }

        public async Task<IActionResult> Index()
        {
            var medicamentos = await repositorioFarmacia.obtener();
            return View(medicamentos);
        }

        public IActionResult noEncontrado()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
