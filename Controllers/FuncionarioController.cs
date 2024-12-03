using Microsoft.AspNetCore.Mvc;

namespace IPVC_Escuta_Vs11.Controllers
{
    public class FuncionarioController : Controller
    {
        // Página inicial do Funcionario
        public IActionResult FuncionarioDashboard()
        {
            return View();
        }
    }
}
