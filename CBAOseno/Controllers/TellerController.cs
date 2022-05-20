using Microsoft.AspNetCore.Mvc;

namespace CBAOseno.WebApi.Controllers
{
    public class TellerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
		
		[HttpGet]
		public IActionResult Assign()
        {
            return View();
        }
		/*[HttpPost]
		public IActionResult Assign()
        {
            return View();
        }*/
		[HttpGet]
		public IActionResult Unassign()
        {
            return View();
        }
		/*[HttpPost]
		public IActionResult Unassign()
        {
            return View();
        }*/
    }
}
