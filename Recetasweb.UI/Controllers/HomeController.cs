using Microsoft.AspNetCore.Mvc;
using Recetasweb.BL.Service;
using Recetasweb.EN;
using Recetasweb.UI.Models;
using Recetasweb.UI.Models.ViewModels;
using System.Diagnostics;

namespace Recetasweb.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRecetaService _RecetaService;

        public HomeController(IRecetaService recetaserv)
        {
            _RecetaService = recetaserv;
        }
        public IActionResult Nueva()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            IQueryable<Recetas> QueryRecetasSQL = await _RecetaService.Mostrar();
            List<VMReceta> lista = QueryRecetasSQL
                .Select(c => new VMReceta()
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Ingredientes = c.Ingredientes,
                    Instrucciones = c.Instrucciones,
                    TiempoDeCoccion = c.TiempoDeCoccion,
                }).ToList();
            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            return StatusCode(StatusCodes.Status200OK, new { test = "gaby"});
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] VMReceta modelo)
        {
            Recetas NuevoModelo = new Recetas()
            {
                Nombre = modelo.Nombre,
                Ingredientes = modelo.Ingredientes,
                Instrucciones = modelo.Instrucciones,
                TiempoDeCoccion = modelo.TiempoDeCoccion

            };
            bool respuesta = await _RecetaService.Insertar(NuevoModelo);
            return StatusCode(StatusCodes.Status200OK, new {valor = respuesta });
        }

        public IActionResult Privacy()
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