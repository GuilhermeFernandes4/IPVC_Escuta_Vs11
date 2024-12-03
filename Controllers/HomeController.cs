using IPVC_Escuta_Vs11.Data; // Acesso ao DbContext
using IPVC_Escuta_Vs11.Models; // Modelos específicos do projeto
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

        // Página inicial do site
        public IActionResult Index()
        {
            return View();
        }

        // Página do Dashboard - Agora com dados das reclamações, sugestões e elogios
        public async Task<IActionResult> Dashboard()
        {
            // Busca os dados de reclamações e sugestões
            var reclamacoesSugestoes = await _context.ReclamacoesSugestoes
                .Select(r => new ReclamacaoSugestao
                {
                    Data = r.Data,                  // Data da reclamação
                    Hora = r.Hora,                  // Hora da reclamação
                    Motivo = r.Motivo,              // Motivo da reclamação
                    DescricaoRec = r.DescricaoRec,  // Descrição da reclamação
                    Categoria = r.Categoria,        // Categoria da reclamação
                    Escola = r.Escola               // Escola associada à reclamação
                })
                .ToListAsync(); // Execute a consulta de forma assíncrona

            // Busca os dados dos elogios
            var elogios = await _context.Elogios
                .Select(e => new Elogios
                {
                    Email = e.Email,                // Email do elogio
                    Opiniao = e.Opiniao,            // Opinião do elogio
                    Avaliacao = e.Avaliacao,        // Avaliação do elogio
                    TipoVisualizacao = e.TipoVisualizacao, // Tipo de visualização do elogio
                    IDReclamacaoSugestao = e.IDReclamacaoSugestao, // Relacionamento com reclamação/sugestão
                    UtilizadorId = e.UtilizadorId   // Id do usuário (se disponível)
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

        // Página de sugestões
        public IActionResult Sugestions()
        {
            return View();
        }

        // Página de elogios
        public IActionResult Compliments()
        {
            return View();
        }

        // Página de reclamações
        public IActionResult Complaints()
        {
            return View();
        }

        // Página Sobre (geral)
        public IActionResult Sobre()
        {
            return View();
        }

        // Página Sobre o Projeto
        public IActionResult Sobre_Projeto()
        {
            return View();
        }

        // Página de Contactos
        public IActionResult Contactos()
        {
            return View();
        }

        // Página de privacidade
        public IActionResult Privacy()
        {
            return View();
        }

        // Página de erros (com ResponseCache)
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
