using Microsoft.AspNetCore.Mvc;

namespace IPVC_Escuta_Vs11.Controllers
{
    public class ProfessorController : Controller
    {
        // Página inicial do Professor
        public IActionResult ProfessorDashboard()
        {
            return View();
        }
    }
}
