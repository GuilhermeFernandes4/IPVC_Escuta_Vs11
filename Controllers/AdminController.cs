using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using IPVC_Escuta_Vs11.Models;
using System.Collections.Generic;

namespace IPVC_Escuta_Vs11.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<Utilizador> _userManager; // Alterado para usar 'Utilizador'
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<Utilizador> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> AdminDashboard()
        {
            // Obtenha todos os utilizadores
            var users = _userManager.Users.ToList();
            var userList = new List<UserRoleViewModel>();

            foreach (var user in users)
            {
                // Obtenha as roles para cada utilizador
                var roles = await _userManager.GetRolesAsync(user);
                userList.Add(new UserRoleViewModel
                {
                    Nome = user.FullName, // Usando a propriedade calculada FullName
                    Email = user.Email,
                    Address = user.Address, // Mostrando o endereço
                    Regist_Date = user.Regist_Date, // Mostrando a data de registro
                    Roles = roles.ToList()
                });
            }

            return View(userList);
        }

        
    }

    // ViewModel para passar os dados para a View
    public class UserRoleViewModel
    {
        internal int Id;

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime? Regist_Date { get; set; }
        public List<string> Roles { get; set; }
    }
}
