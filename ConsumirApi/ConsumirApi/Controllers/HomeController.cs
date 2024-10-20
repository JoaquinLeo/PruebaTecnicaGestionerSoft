using ConsumirApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using ConsumirApi.Servicios;

namespace ConsumirApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicio_API _servicioApi;

        public HomeController(IServicio_API servicioApi)
        {
            _servicioApi = servicioApi;
        }

        public async Task<IActionResult> Index(string peticion)
        {
            Console.WriteLine(peticion);
            List<Datos> lista = await _servicioApi.Lista(peticion);
            return View(lista);
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
