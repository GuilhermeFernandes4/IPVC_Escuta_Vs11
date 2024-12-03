using IPVC_Escuta_Vs11.Data;
using Microsoft.AspNetCore.Mvc;
using IPVC_Escuta_Vs11.Enums;

namespace IPVC_Escuta_Vs11.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly AppDbContext _context;

        // Construtor para injetar o contexto do banco de dados
        public FeedbackController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult AnaliseProgresso()
        {
            // Calculando as contagens com base nos valores da enumeração
            int totalReclamacoes = _context.ReclamacoesSugestoes.Count(rs => rs.TipoFormulario == TipoFormulario.Reclamacao);
            int totalSugestoes = _context.ReclamacoesSugestoes.Count(rs => rs.TipoFormulario == TipoFormulario.Sugestao);
            int totalElogios = _context.Elogios.Count();

            // Somando o total de feedbacks
            int totalFeedbacks = totalReclamacoes + totalSugestoes + totalElogios;

            // Criando o modelo com as propriedades necessárias para a view
            var dadosFeedback = new
            {
                TotalReclamacoes = totalReclamacoes,
                TotalSugestoes = totalSugestoes,
                TotalElogios = totalElogios,
                TotalFeedbacks = totalFeedbacks // Incluído novamente para a view poder acessar
            };

            return View(dadosFeedback);
        }


        // Método para listar todos os usuários na página de gestão de usuários


    }
}
