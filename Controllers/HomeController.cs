using IPVC_Escuta_Vs11.Data; // Acesso ao DbContext
using IPVC_Escuta_Vs11.Models; // Modelos espec�ficos do projeto
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Diagnostics;
using IPVC_Escuta_Vs11.ViewModels;
using IPVC_Escuta_Vs11.Enums;

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
            var reclamacoes = await _context.ReclamacoesSugestoes
            .Where(r => r.TipoFormulario == TipoFormulario.Reclamacao)
            .ToListAsync();

            var sugestoes = await _context.ReclamacoesSugestoes
                .Where(r => r.TipoFormulario == TipoFormulario.Sugestao)
                .ToListAsync();

            var elogios = await _context.Elogios.ToListAsync();

            var viewModel = new DashboardViewModel
            {
                ReclamacoesSugestoes = reclamacoes, // Apenas reclama��es
                Sugestoes = sugestoes,             // Sugest�es separadas
                Elogios = elogios
            };

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
