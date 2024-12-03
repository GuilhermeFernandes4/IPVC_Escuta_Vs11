using IPVC_Escuta_Vs11.Models;
using Microsoft.AspNetCore.Identity;

namespace IPVC_Escuta_Vs11.Data
{
    public static class CreateAdminUser
    {
        public static async Task SeedAsync(UserManager<Utilizador> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Dados do administrador padrão
            var adminEmail = "admin@example.com";
            var adminPassword = "AdminSecurePassword"; // Altere esta senha conforme necessário

            // Verificar se a conta do administrador já existe
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                // Criar o utilizador admin
                Utilizador adminUser = new()
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "User",
                    EmailConfirmed = true
                };

                // Criar o utilizador com a senha fornecida
                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    // Atribuir a role de Admin ao utilizador
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
                else
                {
                    // Logar os erros se a criação falhar
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine(error.Description);
                    }
                }
            }
        }
    }
}
