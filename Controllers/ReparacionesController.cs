using Aplicacion.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace PresentacionWeb.Controllers
{
    public class ReparacionesController : Controller
    {
        private readonly ReparacionService _reparacionService;
        private readonly EquipoService _equipoService;

        public ReparacionesController(
            ReparacionService reparacionService,
            EquipoService equipoService)
        {
            _reparacionService = reparacionService;
            _equipoService = equipoService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _reparacionService.ObtenerReparacionesAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            ViewBag.Equipos = await _equipoService.ObtenerEquiposAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(int idEquipo, string problema)
        {
            try
            {
                await _reparacionService.RegistrarReparacionAsync(idEquipo, problema);
                TempData["Mensaje"] = "Reparación registrada correctamente.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Equipos = await _equipoService.ObtenerEquiposAsync();
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CambiarEstado(int id, string estado)
        {
            try
            {
                await _reparacionService.CambiarEstadoAsync(id, estado);
                TempData["Mensaje"] = "Estado actualizado correctamente.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}