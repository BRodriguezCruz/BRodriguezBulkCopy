using Microsoft.AspNetCore.Mvc;
using PLMVC.Models;
using System.Diagnostics;

namespace PLMVC.Controllers
{
    public class HomeController : Controller
    {
        //nuevo controlador, nuevo metodo
        //GET -mostrar la vista
        //POST -(Archivo IFormFile["file"])
        //llamar al BL mandado el archivo
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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