using IPVC_Escuta_Vs11.Data;
using IPVC_Escuta_Vs11.Enums;
using IPVC_Escuta_Vs11.Models;
using IPVC_Escuta_Vs11.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IPVC_Escuta_Vs11.Controllers
{
    public class ElogioController : Controller
    {
        private readonly AppDbContext dbContext;

        public ElogioController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Métodos de criação de elogios para Aluno, Professor e Funcionário
        [HttpGet]
        [Authorize(Roles = "Aluno")]
        public IActionResult CreateElogio()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Professor")]
        public IActionResult CreateElogioP()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Funcionario")]
        public IActionResult CreateElogioF()
        {
            return View();
        }

        // Métodos POST para criar um novo elogio com tratamento de "Anônimo"
        [HttpPost]
        [Authorize(Roles = "Aluno")]
        public async Task<IActionResult> CreateElogio(CreateElogioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var elogio = new Elogios
            {
                Email = model.TipoVisualizacao == TipoVisualizacao.Privado ? "Anonimo" : User.FindFirst(ClaimTypes.Email)?.Value,
                Opiniao = model.Opiniao,
                Avaliacao = model.Avaliacao,
                TipoVisualizacao = model.TipoVisualizacao,
                IDReclamacaoSugestao = model.IDReclamacaoSugestao,
                UtilizadorId = userId
            };

            await dbContext.Elogios.AddAsync(elogio);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("ListElogio");
        }

        [HttpPost]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> CreateElogioP(CreateElogioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var elogio = new Elogios
            {
                Email = model.TipoVisualizacao == TipoVisualizacao.Privado ? "Anonimo" : User.FindFirst(ClaimTypes.Email)?.Value,
                Opiniao = model.Opiniao,
                Avaliacao = model.Avaliacao,
                TipoVisualizacao = model.TipoVisualizacao,
                IDReclamacaoSugestao = model.IDReclamacaoSugestao,
                UtilizadorId = userId
            };

            await dbContext.Elogios.AddAsync(elogio);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("ListElogioP");
        }

        [HttpPost]
        [Authorize(Roles = "Funcionario")]
        public async Task<IActionResult> CreateElogioF(CreateElogioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var elogio = new Elogios
            {
                Email = model.TipoVisualizacao == TipoVisualizacao.Privado ? "Anonimo" : User.FindFirst(ClaimTypes.Email)?.Value,
                Opiniao = model.Opiniao,
                Avaliacao = model.Avaliacao,
                TipoVisualizacao = model.TipoVisualizacao,
                IDReclamacaoSugestao = model.IDReclamacaoSugestao,
                UtilizadorId = userId
            };

            await dbContext.Elogios.AddAsync(elogio);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("ListElogioF");
        }

        // Métodos para listar os elogios com ajuste para "Anônimo"
        [Authorize(Roles = "Aluno")]
        public async Task<IActionResult> ListElogio()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var elogios = await dbContext.Elogios
                .Where(e => e.UtilizadorId == userId)
                .ToListAsync();

            var viewModelList = elogios.Select(e => new CreateElogioViewModel
            {
                Id = e.Id,
                Email = e.TipoVisualizacao == TipoVisualizacao.Privado ? "Anonimo" : e.Email,
                Opiniao = e.Opiniao,
                Avaliacao = e.Avaliacao,
                TipoVisualizacao = e.TipoVisualizacao,
                IDReclamacaoSugestao = e.IDReclamacaoSugestao
            }).ToList();

            return View(viewModelList);
        }

        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> ListElogioP()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var elogios = await dbContext.Elogios
                .Where(e => e.UtilizadorId == userId)
                .ToListAsync();

            var viewModelList = elogios.Select(e => new CreateElogioViewModel
            {
                Id = e.Id,
                Email = e.TipoVisualizacao == TipoVisualizacao.Privado ? "Anonimo" : e.Email,
                Opiniao = e.Opiniao,
                Avaliacao = e.Avaliacao,
                TipoVisualizacao = e.TipoVisualizacao,
                IDReclamacaoSugestao = e.IDReclamacaoSugestao
            }).ToList();

            return View(viewModelList);
        }

        [Authorize(Roles = "Funcionario")]
        public async Task<IActionResult> ListElogioF()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var elogios = await dbContext.Elogios
                .Where(e => e.UtilizadorId == userId)
                .ToListAsync();

            var viewModelList = elogios.Select(e => new CreateElogioViewModel
            {
                Id = e.Id,
                Email = e.TipoVisualizacao == TipoVisualizacao.Privado ? "Anonimo" : e.Email,
                Opiniao = e.Opiniao,
                Avaliacao = e.Avaliacao,
                TipoVisualizacao = e.TipoVisualizacao,
                IDReclamacaoSugestao = e.IDReclamacaoSugestao
            }).ToList();

            return View(viewModelList);
        }

        // Métodos de edição para todos os papéis

        [HttpGet]
        [Authorize(Roles = "Aluno")]
        public async Task<IActionResult> EditElogio(int id)
        {
            var elogio = await dbContext.Elogios.FindAsync(id);
            if (elogio == null)
            {
                return View("Error");
            }

            var model = new CreateElogioViewModel
            {
                Id = elogio.Id,
                Email = elogio.Email,
                Opiniao = elogio.Opiniao,
                Avaliacao = elogio.Avaliacao,
                TipoVisualizacao = elogio.TipoVisualizacao,
                IDReclamacaoSugestao = elogio.IDReclamacaoSugestao
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Aluno")]
        public async Task<IActionResult> EditElogio(CreateElogioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var elogio = await dbContext.Elogios.FindAsync(model.Id);

            if (elogio == null)
            {
                return View("Error");
            }

            elogio.Opiniao = model.Opiniao;
            elogio.Avaliacao = model.Avaliacao;
            elogio.TipoVisualizacao = model.TipoVisualizacao;
            elogio.IDReclamacaoSugestao = model.IDReclamacaoSugestao;

            await dbContext.SaveChangesAsync();

            return RedirectToAction("ListElogio");
        }

        [HttpGet]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> EditElogioP(int id)
        {
            var elogio = await dbContext.Elogios.FindAsync(id);
            if (elogio == null)
            {
                return View("Error");
            }

            var model = new CreateElogioViewModel
            {
                Id = elogio.Id,
                Email = elogio.Email,
                Opiniao = elogio.Opiniao,
                Avaliacao = elogio.Avaliacao,
                TipoVisualizacao = elogio.TipoVisualizacao,
                IDReclamacaoSugestao = elogio.IDReclamacaoSugestao
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> EditElogioP(CreateElogioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var elogio = await dbContext.Elogios.FindAsync(model.Id);

            if (elogio == null)
            {
                return View("Error");
            }

            elogio.Opiniao = model.Opiniao;
            elogio.Avaliacao = model.Avaliacao;
            elogio.TipoVisualizacao = model.TipoVisualizacao;
            elogio.IDReclamacaoSugestao = model.IDReclamacaoSugestao;

            await dbContext.SaveChangesAsync();

            return RedirectToAction("ListElogioP");
        }

        [HttpGet]
        [Authorize(Roles = "Funcionario")]
        public async Task<IActionResult> EditElogioF(int id)
        {
            var elogio = await dbContext.Elogios.FindAsync(id);
            if (elogio == null)
            {
                return View("Error");
            }

            var model = new CreateElogioViewModel
            {
                Id = elogio.Id,
                Email = elogio.Email,
                Opiniao = elogio.Opiniao,
                Avaliacao = elogio.Avaliacao,
                TipoVisualizacao = elogio.TipoVisualizacao,
                IDReclamacaoSugestao = elogio.IDReclamacaoSugestao
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Funcionario")]
        public async Task<IActionResult> EditElogioF(CreateElogioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var elogio = await dbContext.Elogios.FindAsync(model.Id);

            if (elogio == null)
            {
                return View("Error");
            }

            elogio.Opiniao = model.Opiniao;
            elogio.Avaliacao = model.Avaliacao;
            elogio.TipoVisualizacao = model.TipoVisualizacao;
            elogio.IDReclamacaoSugestao = model.IDReclamacaoSugestao;

            await dbContext.SaveChangesAsync();

            return RedirectToAction("ListElogioF");
        }

        // Métodos de exclusão para cada tipo de elogio

        [HttpGet]
        [Authorize(Roles = "Aluno")]
        public async Task<IActionResult> DeleteElogio(int id)
        {
            var elogio = await dbContext.Elogios.FindAsync(id);
            if (elogio == null)
            {
                return View("Error");
            }

            dbContext.Elogios.Remove(elogio);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("ListElogio");
        }

        [HttpGet]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> DeleteElogioP(int id)
        {
            var elogio = await dbContext.Elogios.FindAsync(id);
            if (elogio == null)
            {
                return View("Error");
            }

            dbContext.Elogios.Remove(elogio);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("ListElogioP");
        }

        [HttpGet]
        [Authorize(Roles = "Funcionario")]
        public async Task<IActionResult> DeleteElogioF(int id)
        {
            var elogio = await dbContext.Elogios.FindAsync(id);
            if (elogio == null)
            {
                return View("Error");
            }

            dbContext.Elogios.Remove(elogio);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("ListElogioF");
        }
    }
}
