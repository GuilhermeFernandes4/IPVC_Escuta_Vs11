using IPVC_Escuta_Vs11.Models;
using IPVC_Escuta_Vs11.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Security.Claims;

namespace IPVC_Escuta_Vs11.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Utilizador> signInManager;
        private readonly UserManager<Utilizador> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(SignInManager<Utilizador> signInManager, UserManager<Utilizador> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        // Página de Login
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username!, model.Password!, model.RememberMe, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    var user = await userManager.FindByNameAsync(model.Username);
                    var roles = await userManager.GetRolesAsync(user);
                    return RedirectToLocal(returnUrl, roles.ToList());
                }

                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "A sua conta foi bloqueada devido a várias tentativas falhadas. Tente novamente mais tarde.");
                }
                else
                {
                    ModelState.AddModelError("", "Tentativa de login inválida. Verifique suas credenciais.");
                }
            }
            return View(model);
        }

        // Página de Registro
        public IActionResult Register(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            var model = new RegisterVM
            {
                RegisterDate = DateTime.Now
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                Utilizador user = new()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.Email,
                    Email = model.Email,
                    Address = model.Address
                };

                var result = await userManager.CreateAsync(user, model.Password!);

                if (result.Succeeded)
                {
                    if (await roleManager.RoleExistsAsync(model.Role))
                    {
                        await userManager.AddToRoleAsync(user, model.Role);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Role inválida fornecida.");
                        return View(model);
                    }
                    await signInManager.SignInAsync(user, isPersistent: false);

                    if (await userManager.IsInRoleAsync(user, "Aluno"))
                    {
                        return RedirectToAction("Index", "Aluno");
                    }

                    return RedirectToLocal(returnUrl);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        // Logout
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // Página de Perfil do Utilizador
        [Authorize]
        public async Task<IActionResult> Perfil()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            var viewModel = new PerfilViewModel
            {
                Nome = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                Address = user.Address
            };

            return View(viewModel);
        }

        // Página de Edição do Perfil
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditPerfil()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            var viewModel = new EditPerfilViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPerfil(EditPerfilViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Address = model.Address;

            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Perfil));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        // Métodos Auxiliares
        private IActionResult RedirectToLocal(string? returnUrl, IList<string> roles)
        {
            if (roles.Contains("Admin"))
            {
                return RedirectToAction("AdminDashboard", "Admin");
            }
            else if (roles.Contains("Professor"))
            {
                return RedirectToAction("ProfessorDashboard", "Professor");
            }
            else if (roles.Contains("Funcionario"))
            {
                return RedirectToAction("FuncionarioDashboard", "Funcionario");
            }
            else if (roles.Contains("Aluno"))
            {
                return RedirectToAction("Index", "Aluno");
            }
            else
            {
                return !string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl)
                    ? Redirect(returnUrl)
                    : RedirectToAction(nameof(HomeController.Index), nameof(HomeController));
            }
        }

        private IActionResult RedirectToLocal(string? returnUrl)
        {
            var user = userManager.FindByNameAsync(User.Identity?.Name).Result;
            var roles = userManager.GetRolesAsync(user).Result;

            return RedirectToLocal(returnUrl, roles.ToList());
        }
    }
}
