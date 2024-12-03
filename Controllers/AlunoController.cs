using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPVC_Escuta_Vs11.Controllers
{
    [Authorize(Roles = "Aluno")] // Apenas usuários com a role "Aluno" podem acessar este controlador
    public class AlunoController : Controller
    {
        public IActionResult Index()
        {
            // Aqui você pode adicionar a lógica para buscar os dados do aluno,
            // por exemplo, informações do perfil, cursos, etc.
            return View(); // Retorna a View do aluno
        }

        // Aqui você pode adicionar mais ações conforme necessário
        // Exemplo: visualização de notas, cursos, etc.

        public IActionResult Profile()
        {
            // Ação para exibir o perfil do aluno
            // Aqui você pode buscar os dados do aluno e passá-los para a View

            return View(); // Retorna a View do perfil do aluno
        }
    }
}
