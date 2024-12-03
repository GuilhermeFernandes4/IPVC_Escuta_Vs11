using IPVC_Escuta_Vs11.Data;
using IPVC_Escuta_Vs11.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IPVC_Escuta_Vs11
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configuração do DbContext para a conexão com o banco de dados
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Configurar Identity com suporte a roles e ajustes de senha
            builder.Services.AddIdentity<Utilizador, IdentityRole>(options =>
            {
                // Requisitos de senha
                options.Password.RequiredUniqueChars = 1; // Ao menos 1 caractere único
                options.Password.RequireUppercase = true; // Deve conter letras maiúsculas
                options.Password.RequiredLength = 8; // Mínimo de 8 caracteres
                options.Password.RequireNonAlphanumeric = true; // Deve conter caracteres não alfanuméricos
                options.Password.RequireLowercase = true; // Deve conter letras minúsculas
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            // Adicionar os serviços do MVC
            builder.Services.AddControllersWithViews();

            // Configuração para autenticação e autorização
            builder.Services.AddAuthentication()
                .AddCookie(options =>
                {
                    options.LoginPath = "/Home/Login"; // Caminho para login personalizado se necessário
                });

            var app = builder.Build();

            // Chamar SeedRoles e SeedAdminUser após a construção do aplicativo dentro de um escopo
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    var userManager = services.GetRequiredService<UserManager<Utilizador>>();

                    // Chamar os métodos de seed
                    await CreateRoles(roleManager);
                    await CreateAdminUser(userManager, roleManager, services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Ocorreu um erro ao criar as roles ou o usuário administrador.");
                }
            }

            // Configure o pipeline de requisições
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Autenticação e autorização
            app.UseAuthentication();
            app.UseAuthorization();

            // Definindo a rota padrão do MVC
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Inicia o aplicativo
            app.Run();
        }

        // Método para criar as roles no banco de dados
        private static async Task CreateRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin", "Professor", "Funcionario", "Aluno" }; // Defina as roles necessárias
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        // Método para criar o utilizador admin e atribuir a role de Admin
        private static async Task CreateAdminUser(UserManager<Utilizador> userManager, RoleManager<IdentityRole> roleManager, IServiceProvider services)
        {
            // Dados do administrador padrão
            var adminEmail = "admin@example.com";
            var adminPassword = "Mascote2004."; // Altere esta senha conforme necessário

            // Verificar se o administrador já existe
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                // Criar o utilizador admin
                Utilizador adminUser = new()
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "User",
                    EmailConfirmed = true // Confirmar o e-mail se necessário
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
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    foreach (var error in result.Errors)
                    {
                        logger.LogError(error.Description);
                    }
                }
            }
        }
    }
}
