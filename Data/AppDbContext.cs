using IPVC_Escuta_Vs11.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace IPVC_Escuta_Vs11.Data;

public class AppDbContext : IdentityDbContext<Utilizador>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<Estado> Estados { get; set; }
    public DbSet<Utilizador> Utilizadores { get; set; }
    public DbSet<ReclamacaoSugestao> ReclamacoesSugestoes { get; set; }
    public DbSet<DenunciaR> DenunciasR { get; set; }
    public DbSet<RespostaR> RespostasR { get; set; }
    public DbSet<ComentarioS> ComentariosS { get; set; }
    public DbSet<EstadoRS> EstadosRS { get; set; }
    public DbSet<Elogios> Elogios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        {
            builder.Entity<ReclamacaoSugestao>()
            .HasOne(rs => rs.Utilizador)
            .WithMany(u => u.ReclamacoesSugestoes)
            .HasForeignKey(rs => rs.UtilizadorId)
            .OnDelete(DeleteBehavior.Cascade);

        }
    }

}

