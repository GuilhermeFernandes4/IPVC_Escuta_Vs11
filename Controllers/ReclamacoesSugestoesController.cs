using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using IPVC_Escuta_Vs11.Data;
using IPVC_Escuta_Vs11.Models;
using IPVC_Escuta_Vs11.ViewModels;
using IPVC_Escuta_Vs11.Enums;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace IPVC_Escuta_Vs11.Controllers
{
    public class ReclamacoesSugestoesController : Controller
    {
        private readonly AppDbContext dbContext;

        public ReclamacoesSugestoesController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Métodos Create

        [HttpGet]
        [Authorize(Roles = "Aluno")]
        public IActionResult CreateSugestaoReclamacao()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Professor")]
        public IActionResult CreateSugestaoReclamacaoP()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Funcionario")]
        public IActionResult CreateSugestaoReclamacaoF()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Aluno")]
        public async Task<IActionResult> CreateSugestaoReclamacao(CreateSugestaoReclamacaoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var reclamacaoSugestao = new ReclamacaoSugestao()
            {
                TipoFormulario = model.TipoFormulario,
                Data = model.Data,
                Hora = model.Hora,
                Motivo = model.Motivo,
                DescricaoRec = model.DescricaoRec,
                Categoria = model.Categoria,
                Escola = model.Escola,
                UtilizadorId = userId
            };

            await dbContext.ReclamacoesSugestoes.AddAsync(reclamacaoSugestao);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("ListSugestoesReclamacoes");
        }

        [HttpPost]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> CreateSugestaoReclamacaoP(CreateSugestaoReclamacaoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var reclamacaoSugestao = new ReclamacaoSugestao()
            {
                TipoFormulario = model.TipoFormulario,
                Data = model.Data,
                Hora = model.Hora,
                Motivo = model.Motivo,
                DescricaoRec = model.DescricaoRec,
                Categoria = model.Categoria,
                Escola = model.Escola,
                UtilizadorId = userId
            };

            await dbContext.ReclamacoesSugestoes.AddAsync(reclamacaoSugestao);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("ListSugestoesReclamacoesP");
        }

        [HttpPost]
        [Authorize(Roles = "Funcionario")]
        public async Task<IActionResult> CreateSugestaoReclamacaoF(CreateSugestaoReclamacaoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var reclamacaoSugestao = new ReclamacaoSugestao()
            {
                TipoFormulario = model.TipoFormulario,
                Data = model.Data,
                Hora = model.Hora,
                Motivo = model.Motivo,
                DescricaoRec = model.DescricaoRec,
                Categoria = model.Categoria,
                Escola = model.Escola,
                UtilizadorId = userId
            };

            await dbContext.ReclamacoesSugestoes.AddAsync(reclamacaoSugestao);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("ListSugestoesReclamacoesF");
        }

        // Métodos Listar

        [Authorize(Roles = "Aluno")]
        public async Task<IActionResult> ListSugestoesReclamacoes()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var reclamacoesSugestoes = await dbContext.ReclamacoesSugestoes
                .Where(r => r.UtilizadorId == userId)
                .ToListAsync();

            var viewModelList = reclamacoesSugestoes.Select(r => new CreateSugestaoReclamacaoViewModel
            {
                IDReclamacaoSugestao = r.IDReclamacaoSugestao,
                TipoFormulario = r.TipoFormulario,
                Data = r.Data,
                Hora = r.Hora,
                Motivo = r.Motivo,
                DescricaoRec = r.DescricaoRec,
                Categoria = r.Categoria,
                Escola = r.Escola
            }).ToList();

            return View(viewModelList);
        }

        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> ListSugestoesReclamacoesP()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var reclamacoesSugestoes = await dbContext.ReclamacoesSugestoes
                .Where(r => r.UtilizadorId == userId || r.UtilizadorId == null) // Inclui as sugestões do professor
                .ToListAsync();

            var viewModelList = reclamacoesSugestoes.Select(r => new CreateSugestaoReclamacaoViewModel
            {
                IDReclamacaoSugestao = r.IDReclamacaoSugestao,
                TipoFormulario = r.TipoFormulario,
                Data = r.Data,
                Hora = r.Hora,
                Motivo = r.Motivo,
                DescricaoRec = r.DescricaoRec,
                Categoria = r.Categoria,
                Escola = r.Escola
            }).ToList();

            return View(viewModelList);
        }

        [Authorize(Roles = "Funcionario")]
        public async Task<IActionResult> ListSugestoesReclamacoesF()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtém o ID do usuário logado
            var reclamacoesSugestoes = await dbContext.ReclamacoesSugestoes
                .Where(r => r.UtilizadorId == userId) // Filtra apenas as sugestões e reclamações do funcionário
                .ToListAsync();

            var viewModelList = reclamacoesSugestoes.Select(r => new CreateSugestaoReclamacaoViewModel
            {
                IDReclamacaoSugestao = r.IDReclamacaoSugestao,
                TipoFormulario = r.TipoFormulario,
                Data = r.Data,
                Hora = r.Hora,
                Motivo = r.Motivo,
                DescricaoRec = r.DescricaoRec,
                Categoria = r.Categoria,
                Escola = r.Escola
            }).ToList();

            return View(viewModelList);
        }

        // Métodos Editar

        [HttpGet]
        [Authorize(Roles = "Aluno")]
        public async Task<IActionResult> EditSugestaoReclamacao(int IDReclamacaoSugestao)
        {
            // Busca a sugestão ou reclamação no banco de dados
            var reclamacaoSugestao = await dbContext.ReclamacoesSugestoes.FindAsync(IDReclamacaoSugestao);

            // Verifica se a reclamação/sugestão foi encontrada
            if (reclamacaoSugestao == null)
            {
                return NotFound(); // Retorna 404 se não encontrado
            }

            // Cria o modelo de edição
            var model = new CreateSugestaoReclamacaoViewModel
            {
                IDReclamacaoSugestao = reclamacaoSugestao.IDReclamacaoSugestao,
                TipoFormulario = reclamacaoSugestao.TipoFormulario,
                Data = reclamacaoSugestao.Data,
                Hora = reclamacaoSugestao.Hora,
                Motivo = reclamacaoSugestao.Motivo,
                DescricaoRec = reclamacaoSugestao.DescricaoRec,
                Categoria = reclamacaoSugestao.Categoria,
                Escola = reclamacaoSugestao.Escola
            };

            // Retorna a view com o modelo preenchido
            return View(model);
        }


        [HttpGet]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> EditSugestaoReclamacaoP(int IDReclamacaoSugestao)
        {
            // Busca a sugestão ou reclamação no banco de dados
            var reclamacaoSugestao = await dbContext.ReclamacoesSugestoes.FindAsync(IDReclamacaoSugestao);

            // Verifica se a reclamação/sugestão foi encontrada
            if (reclamacaoSugestao == null)
            {
                return NotFound(); // Retorna 404 se não encontrado
            }

            // Cria o modelo de edição
            var model = new CreateSugestaoReclamacaoViewModel
            {
                IDReclamacaoSugestao = reclamacaoSugestao.IDReclamacaoSugestao,
                TipoFormulario = reclamacaoSugestao.TipoFormulario,
                Data = reclamacaoSugestao.Data,
                Hora = reclamacaoSugestao.Hora,
                Motivo = reclamacaoSugestao.Motivo,
                DescricaoRec = reclamacaoSugestao.DescricaoRec,
                Categoria = reclamacaoSugestao.Categoria,
                Escola = reclamacaoSugestao.Escola
            };

            // Retorna a view com o modelo preenchido
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Funcionario")]
        public async Task<IActionResult> EditSugestaoReclamacaoF(int IDReclamacaoSugestao)
        {
            // Busca a sugestão ou reclamação no banco de dados
            var reclamacaoSugestao = await dbContext.ReclamacoesSugestoes.FindAsync(IDReclamacaoSugestao);

            // Verifica se a reclamação/sugestão foi encontrada
            if (reclamacaoSugestao == null)
            {
                return NotFound(); // Retorna 404 se não encontrado
            }

            // Cria o modelo de edição
            var model = new CreateSugestaoReclamacaoViewModel
            {
                IDReclamacaoSugestao = reclamacaoSugestao.IDReclamacaoSugestao,
                TipoFormulario = reclamacaoSugestao.TipoFormulario,
                Data = reclamacaoSugestao.Data,
                Hora = reclamacaoSugestao.Hora,
                Motivo = reclamacaoSugestao.Motivo,
                DescricaoRec = reclamacaoSugestao.DescricaoRec,
                Categoria = reclamacaoSugestao.Categoria,
                Escola = reclamacaoSugestao.Escola
            };

            // Retorna a view com o modelo preenchido
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Aluno")]
        public async Task<IActionResult> EditSugestaoReclamacao(CreateSugestaoReclamacaoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Retorna a view se o modelo não for válido
            }

            var reclamacaoSugestao = await dbContext.ReclamacoesSugestoes.FindAsync(model.IDReclamacaoSugestao);
            if (reclamacaoSugestao == null)
            {
                return NotFound();
            }

            // Atualiza os campos da entidade com os dados do modelo
            reclamacaoSugestao.TipoFormulario = model.TipoFormulario;
            reclamacaoSugestao.Data = model.Data;
            reclamacaoSugestao.Hora = model.Hora;
            reclamacaoSugestao.Motivo = model.Motivo;
            reclamacaoSugestao.DescricaoRec = model.DescricaoRec;
            reclamacaoSugestao.Categoria = model.Categoria;
            reclamacaoSugestao.Escola = model.Escola;

            await dbContext.SaveChangesAsync(); // Salva as alterações no banco de dados
            return RedirectToAction("ListSugestoesReclamacoes"); // Redireciona para a lista de sugestões/reclamações
        }

        [HttpPost]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> EditSugestaoReclamacaoP(CreateSugestaoReclamacaoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Retorna a view se o modelo não for válido
            }

            var reclamacaoSugestao = await dbContext.ReclamacoesSugestoes.FindAsync(model.IDReclamacaoSugestao);
            if (reclamacaoSugestao == null)
            {
                return NotFound();
            }

            // Atualiza os campos da entidade com os dados do modelo
            reclamacaoSugestao.TipoFormulario = model.TipoFormulario;
            reclamacaoSugestao.Data = model.Data;
            reclamacaoSugestao.Hora = model.Hora;
            reclamacaoSugestao.Motivo = model.Motivo;
            reclamacaoSugestao.DescricaoRec = model.DescricaoRec;
            reclamacaoSugestao.Categoria = model.Categoria;
            reclamacaoSugestao.Escola = model.Escola;

            await dbContext.SaveChangesAsync(); // Salva as alterações no banco de dados
            return RedirectToAction("ListSugestoesReclamacoesP"); // Redireciona para a lista de sugestões/reclamações
        }




        [HttpPost]
        [Authorize(Roles = "Funcionario")]
        public async Task<IActionResult> EditSugestaoReclamacaoF(CreateSugestaoReclamacaoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var reclamacaoSugestao = await dbContext.ReclamacoesSugestoes.FindAsync(model.IDReclamacaoSugestao);
            if (reclamacaoSugestao == null)
            {
                return NotFound();
            }
            reclamacaoSugestao.TipoFormulario = model.TipoFormulario;
            reclamacaoSugestao.Data = model.Data;
            reclamacaoSugestao.Hora = model.Hora;
            reclamacaoSugestao.Motivo = model.Motivo;
            reclamacaoSugestao.DescricaoRec = model.DescricaoRec;
            reclamacaoSugestao.Categoria = model.Categoria;
            reclamacaoSugestao.Escola = model.Escola;

            await dbContext.SaveChangesAsync();
            return RedirectToAction("ListSugestoesReclamacoesF");
        }

        [HttpGet]
        [Authorize(Roles = "Aluno")]
        public async Task<IActionResult> DeleteSugestaoReclamacao(int IDReclamacaoSugestao)
        {
            var reclamacaosugestao = await dbContext.ReclamacoesSugestoes.FindAsync(IDReclamacaoSugestao);
            if (reclamacaosugestao == null)
            {
                return View("Error");
            }

            dbContext.ReclamacoesSugestoes.Remove(reclamacaosugestao);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("ListSugestoesReclamacoes");
        }

        [HttpGet]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> DeleteSugestaoReclamacaoP(int IDReclamacaoSugestao)
        {
            var reclamacaosugestao = await dbContext.ReclamacoesSugestoes.FindAsync(IDReclamacaoSugestao);
            if (reclamacaosugestao == null)
            {
                return View("Error");
            }

            dbContext.ReclamacoesSugestoes.Remove(reclamacaosugestao);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("ListSugestoesReclamacoesP");
        }

        [HttpGet]
        [Authorize(Roles = "Funcionario")]
        public async Task<IActionResult> DeleteSugestaoReclamacaoF(int IDReclamacaoSugestao)
        {
            var reclamacaosugestao = await dbContext.ReclamacoesSugestoes.FindAsync(IDReclamacaoSugestao);
            if (reclamacaosugestao == null)
            {
                return View("Error");
            }

            dbContext.ReclamacoesSugestoes.Remove(reclamacaosugestao);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("ListSugestoesReclamacoesF");
        }




    }
}
