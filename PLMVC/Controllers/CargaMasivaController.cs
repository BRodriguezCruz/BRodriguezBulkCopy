using Microsoft.AspNetCore.Mvc;

namespace PLMVC.Controllers
{
    public class CargaMasivaController : Controller
    {

        [HttpGet] 
        public IActionResult BulkCopy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BulkCopy(ML.Result result)
        {
           IFormFile file = Request.Form.Files["csv"];

            ML.Result result1 = BL.BulkCopy.BulkCopySql(file);

            return View(result1);
        }
    }
}
