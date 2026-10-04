using Aplicacion.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace PresentacionWeb.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ClienteService _clienteService;

        public ClientesController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteService.ObtenerClientesAsync();
            return View(clientes);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(
            string nombre,
            string telefono,
            string? correo,
            string? direccion)
        {
            try
            {
                await _clienteService.RegistrarClienteAsync(
                    nombre,
                    telefono,
                    correo,
                    direccion);

                TempData["Mensaje"] = "Cliente registrado correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}