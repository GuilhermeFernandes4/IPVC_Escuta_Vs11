using Microsoft.AspNetCore.Mvc;
using IPVC_Escuta_Vs11.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IPVC_Escuta_Vs11.ViewModels;
using IPVC_Escuta_Vs11.Data;
using System.Linq;

namespace IPVC_Escuta_Vs11.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<Utilizador> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<Utilizador> _signInManager;
        private readonly AppDbContext dbContext;

        public UserController(UserManager<Utilizador> userManager, RoleManager<IdentityRole> roleManager, SignInManager<Utilizador> signInManager, AppDbContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            this.dbContext = dbContext;
        }

        // Método para exibir todos os utilizadores
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users;
            return View(await users.ToListAsync());
        }

        // Método para criar um utilizador (GET)
        [HttpGet]
        public IActionResult CreateUser()
        {
            
            return View();
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(CreateUserAdminViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Utilizador() { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, Address = model.Address};
                // Cria o utilizador na base de dados
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Adicionar a Role ao utilizador
                    if (!string.IsNullOrEmpty(model.Role))
                    {
                        await _userManager.AddToRoleAsync(user, model.Role);
                    }
                    

                    // Redireciona para a página de gestão de utilizadores
                    return RedirectToAction("User_Manager");
                }
                else
                {
                    // Registra erros no ModelState
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);
        }


        // Método para editar utilizador (GET)
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userID = user.Id.ToString();

            var roleID = await dbContext.UserRoles.Where(ur => ur.UserId == userID).Select(ur => ur.RoleId).FirstOrDefaultAsync();

            var role = await dbContext.Roles.FindAsync(roleID);

            var roleName = await _roleManager.GetRoleNameAsync(role);

            var model = new EditUserAdminViewModel() { Address = user.Address, Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, Role = roleName , Id = user.Id};
        
            return View(model);  // Reutiliza a view de criação para editar
        }

        // Método para editar utilizador (POST)
        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserAdminViewModel edit)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByIdAsync(edit.Id.ToString());

                if (existingUser == null)
                {
                    return NotFound();
                }

                // Atualiza os dados
                existingUser.FirstName = edit.FirstName;
                existingUser.LastName = edit.LastName;
                existingUser.Email = edit.Email;
                existingUser.Address = edit.Address;

                

                // Atualiza a Role, se necessário
                var currentRoles = await _userManager.GetRolesAsync(existingUser);
                if (!string.IsNullOrEmpty(edit.Role) && !currentRoles.Contains(edit.Role))
                {
                    foreach (var currentRole in currentRoles)
                    {
                        await _userManager.RemoveFromRoleAsync(existingUser, currentRole);
                    }

                    var roleResult = await _userManager.AddToRoleAsync(existingUser, edit.Role);
                    if (!roleResult.Succeeded)
                    {
                        foreach (var error in roleResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }

                var updateResult = await _userManager.UpdateAsync(existingUser);

                if (updateResult.Succeeded)
                {
                    return RedirectToAction("User_Manager"); // Após a edição, redireciona para a lista
                }
                else
                {
                    foreach (var error in updateResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            ViewBag.Roles = new[] { "Aluno", "Funcionario", "Professor" };
            return View(); // Caso falhe, retorna à mesma view
        }


        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                // Get the roles assigned to the user
                var userRoles = await _userManager.GetRolesAsync(user);

                // Check if the user is in the "Admin" role
                if (userRoles.Contains("Admin"))
                {

                    return RedirectToAction("User_Manager");
                }

                // Proceed with deletion if the user is not in the "Admin" role
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                { 
                    return RedirectToAction("User_Manager");
                }
                else
                {
                    // Handle errors during deletion
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }


            return RedirectToAction("User_Manager");
        }


        // Método para listar todos os usuários na página de gestão de usuários
        [HttpGet]
        public IActionResult User_Manager()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        // Método para listar todos os usuários na página de progresso (caso você tenha uma)
        [HttpGet]
        public IActionResult Progress()
        {
            return View();
        }
    }
}
