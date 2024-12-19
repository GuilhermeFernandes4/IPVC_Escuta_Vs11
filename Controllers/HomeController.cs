using IPVC_Escuta_Vs11.Data; // Acesso ao DbContext
using IPVC_Escuta_Vs11.Models; // Modelos específicos do projeto
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

        // Página inicial do site
        public IActionResult Index()
        {
            return View();
        }

        // Página do Dashboard - Agora com dados das reclamações, sugestões e elogios
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
                ReclamacoesSugestoes = reclamacoes, // Apenas reclamações
                Sugestoes = sugestoes,             // Sugestões separadas
                Elogios = elogios
            };

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
