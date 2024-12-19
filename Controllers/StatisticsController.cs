using IPVC_Escuta_Vs11.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

public class StatisticsController : Controller
{
    private readonly UserManager<Utilizador> _userManager;

    public StatisticsController(UserManager<Utilizador> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Reports()
    {
        // Consultar os dados reais para estatísticas
        var totalUsers = await _userManager.Users.CountAsync();
        var activeUsers = await _userManager.Users.CountAsync(u => u.IsActive);
        var inactiveUsers = totalUsers - activeUsers;
        var newRegistrations = await _userManager.Users.CountAsync(u => u.Regist_Date > DateTime.Now.AddMonths(-1));

        // Verifica se o utilizador logado está ativo
        var loggedInUser = await _userManager.GetUserAsync(User);
        var loggedInUserActive = loggedInUser != null && loggedInUser.IsActive;

        // Atualiza a contagem de usuários ativos para incluir o usuário logado se ele estiver ativo
        if (loggedInUserActive)
        {
            activeUsers++;
        }

        var reportData = new
        {
            TotalUsers = totalUsers,
            ActiveUsers = activeUsers,
            InactiveUsers = inactiveUsers,
            NewRegistrations = newRegistrations
        };

        return View(reportData);
    }
}
