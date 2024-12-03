using IPVC_Escuta_Vs11.Data; // Acesso ao DbContext
using IPVC_Escuta_Vs11.Models; // Modelos espec�ficos do projeto
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Diagnostics;
using IPVC_Escuta_Vs11.ViewModels;

namespace IPVC_Escuta_Vs11.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context; // Adiciona o contexto do banco de dados

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context; // Inicializa o contexto
        }

        // P�gina inicial do site
        public IActionResult Index()
        {
            return View();
        }

        // P�gina do Dashboard - Agora com dados das reclama��es, sugest�es e elogios
        public async Task<IActionResult> Dashboard()
        {
            // Busca os dados de reclama��es e sugest�es
            var reclamacoesSugestoes = await _context.ReclamacoesSugestoes
                .Select(r => new ReclamacaoSugestao
                {
                    Data = r.Data,                  // Data da reclama��o
                    Hora = r.Hora,                  // Hora da reclama��o
                    Motivo = r.Motivo,              // Motivo da reclama��o
                    DescricaoRec = r.DescricaoRec,  // Descri��o da reclama��o
                    Categoria = r.Categoria,        // Categoria da reclama��o
                    Escola = r.Escola               // Escola associada � reclama��o
                })
                .ToListAsync(); // Execute a consulta de forma ass�ncrona

            // Busca os dados dos elogios
            var elogios = await _context.Elogios
                .Select(e => new Elogios
                {
                    Email = e.Email,                // Email do elogio
                    Opiniao = e.Opiniao,            // Opini�o do elogio
                    Avaliacao = e.Avaliacao,        // Avalia��o do elogio
                    TipoVisualizacao = e.TipoVisualizacao, // Tipo de visualiza��o do elogio
                    IDReclamacaoSugestao = e.IDReclamacaoSugestao, // Relacionamento com reclama��o/sugest�o
                    UtilizadorId = e.UtilizadorId   // Id do usu�rio (se dispon�vel)
                })
                .ToListAsync();

            // Cria o ViewModel combinando ambos os dados
            var viewModel = new DashboardViewModel
            {
                ReclamacoesSugestoes = reclamacoesSugestoes,
                Elogios = elogios
            };

            // Retorna os dados para a View
            return View(viewModel);
        }

        // P�gina de sugest�es
        public IActionResult Sugestions()
        {
            return View();
        }

        // P�gina de elogios
        public IActionResult Compliments()
        {
            return View();
        }

        // P�gina de reclama��es
        public IActionResult Complaints()
        {
            return View();
        }

        // P�gina Sobre (geral)
        public IActionResult Sobre()
        {
            return View();
        }

        // P�gina Sobre o Projeto
        public IActionResult Sobre_Projeto()
        {
            return View();
        }

        // P�gina de Contactos
        public IActionResult Contactos()
        {
            return View();
        }

        // P�gina de privacidade
        public IActionResult Privacy()
        {
            return View();
        }

        // P�gina de erros (com ResponseCache)
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
