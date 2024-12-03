using Microsoft.AspNetCore.Mvc;

namespace IPVC_Escuta_Vs11.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
