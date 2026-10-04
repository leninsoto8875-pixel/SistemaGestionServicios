using Aplicacion.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace PresentacionWeb.Controllers
{
    public class EquiposController : Controller
    {
        private readonly EquipoService _equipoService;
        private readonly ClienteService _clienteService;

        public EquiposController(
            EquipoService equipoService,
            ClienteService clienteService)
        {
            _equipoService = equipoService;
            _clienteService = clienteService;
        }

        public async Task<IActionResult> Index()
        {
            var equipos = await _equipoService.ObtenerEquiposAsync();
            return View(equipos);
        }

        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            ViewBag.Clientes = await _clienteService.ObtenerClientesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(
            int idCliente,
            string tipo,
            string marca,
            string? modelo,
            string? numeroSerie,
            string? descripcion)
        {
            try
            {
                await _equipoService.RegistrarEquipoAsync(
                    idCliente,
                    tipo,
                    marca,
                    modelo,
                    numeroSerie,
                    descripcion);

                TempData["Mensaje"] = "Equipo registrado correctamente.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Clientes = await _clienteService.ObtenerClientesAsync();
                return View();
            }
        }
    }
}