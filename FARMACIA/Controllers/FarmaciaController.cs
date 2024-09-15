using FARMACIA.Models;
using FARMACIA.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace FARMACIA.Controllers
{
    public class FarmaciaController : Controller
    {
        private readonly IRepositorioFarmacia repositorioFarmacia;

        public FarmaciaController(IRepositorioFarmacia repositorioFarmacia)
        {
            this.repositorioFarmacia = repositorioFarmacia;
        }

        public async Task<IActionResult> medicamentos()
        {
            var medicamentos = await repositorioFarmacia.obtener();
            return View(medicamentos);
        }


        public ActionResult crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> crear(MedicamentoViewModel medicamentoViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View(medicamentoViewModel);
            }

            medicamentoViewModel.GsId = 1;

            await repositorioFarmacia.crear(medicamentoViewModel);

            return RedirectToAction("medicamentos");
        }


        [HttpGet]
        public async Task<IActionResult> editar(int gsId)
        {
            var medicamento = await repositorioFarmacia.obtenerPorId(gsId);

            if (medicamento is null)
            {
                return RedirectToAction("noEncontrado", "Home");
            }
            return View(medicamento);
        }

        [HttpPost]
        public async Task<IActionResult> editar(MedicamentoViewModel medicamentoViewModel)
        {
            var medicamentoExiste = await repositorioFarmacia.obtenerPorId(medicamentoViewModel.GsId);

            if (medicamentoExiste is null)
            {
                return RedirectToAction("noEncontrado", "Home");
            }

            await repositorioFarmacia.actualizar(medicamentoViewModel);
            return RedirectToAction("medicamentos");
        }

        [HttpGet]
        public async Task<IActionResult> borrar(int id)
        {
            var medicamento = await repositorioFarmacia.obtenerPorId(id);

            if (medicamento is null)
            {
                return RedirectToAction("noEncontrado", "Home");
            }
            return View(medicamento);
        }

        [HttpPost]
        public async Task<IActionResult> borrar(MedicamentoViewModel medicamentoViewModel)
        {
            var medicamentoExiste = await repositorioFarmacia.obtenerPorId(medicamentoViewModel.GsId);

            if (medicamentoExiste is null)
            {
                return RedirectToAction("noEncontrado", "Home");
            }

            await repositorioFarmacia.borrar(medicamentoViewModel.GsId);
            return RedirectToAction("medicamentos");
        }
    }
}
