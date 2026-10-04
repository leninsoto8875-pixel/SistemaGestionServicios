using Aplicacion.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace PresentacionWeb.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ProductoService _productoService;

        public ProductosController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        public async Task<IActionResult> Index()
        {
            var productos = await _productoService.ObtenerProductosAsync();
            return View(productos);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(
            string nombre,
            string? descripcion,
            decimal precio,
            int stock)
        {
            try
            {
                await _productoService.RegistrarProductoAsync(
                    nombre, descripcion, precio, stock);

                TempData["Mensaje"] = "Producto registrado correctamente.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}