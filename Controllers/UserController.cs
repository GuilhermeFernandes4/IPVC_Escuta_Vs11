using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IPVC_Escuta_Vs11.ViewModels;
using IPVC_Escuta_Vs11.Models;
using IPVC_Escuta_Vs11.Data;
using System.Linq;

namespace IPVC_Escuta_Vs11.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<Utilizador> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<Utilizador> _signInManager;
        private readonly AppDbContext _dbContext;

        public UserController(
            UserManager<Utilizador> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<Utilizador> signInManager,
            AppDbContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        // Exibir todos os utilizadores
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }

        // Criar um novo utilizador (GET)
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        // Criar um novo utilizador (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(CreateUserAdminViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new Utilizador
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(model.Role))
                {
                    await _userManager.AddToRoleAsync(user, model.Role);
                }

                return RedirectToAction("User_Manager");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        // Editar utilizador (GET)
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            // Obtém a Role atual
            var currentRoleId = await _dbContext.UserRoles
                .Where(ur => ur.UserId == user.Id)
                .Select(ur => ur.RoleId)
                .FirstOrDefaultAsync();

            var role = await _dbContext.Roles.FindAsync(currentRoleId);
            var roleName = role?.Name;

            var model = new EditUserAdminViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                Role = roleName
            };

            return View(model);
        }

        // Editar utilizador (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUserAdminViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
                return NotFound();

            // Atualizar campos do utilizador
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.Address = model.Address;

            // Atualizar a Role, se necessário
            var currentRoles = await _userManager.GetRolesAsync(user);
            if (!string.IsNullOrEmpty(model.Role) && !currentRoles.Contains(model.Role))
            {
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
                await _userManager.AddToRoleAsync(user, model.Role);
            }

            var updateResult = await _userManager.UpdateAsync(user);
            if (updateResult.Succeeded)
            {
                return RedirectToAction("User_Manager");
            }

            foreach (var error in updateResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        // Excluir utilizador
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return RedirectToAction("User_Manager");

            // Verificar se há registros relacionados
            var hasRelatedEntries = await _dbContext.ReclamacoesSugestoes
                .AnyAsync(r => r.UtilizadorId == user.Id);

            if (hasRelatedEntries)
                return RedirectToAction("User_Manager");

            // Verificar se é a própria conta do utilizador logado
            if (User.Identity.Name == user.UserName)
            {
                ModelState.AddModelError("", "Não é permitido excluir sua própria conta.");
                return RedirectToAction("User_Manager");
            }

            // Excluir o utilizador
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return RedirectToAction("User_Manager");
        }

        // Listar utilizadores para a página de gestão
        [HttpGet]
        public IActionResult User_Manager()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        // Página de progresso (se necessário)
        [HttpGet]
        public IActionResult Progress()
        {
            return View();
        }
    }
}
