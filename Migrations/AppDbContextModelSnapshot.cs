﻿// <auto-generated />
using System;
using IPVC_Escuta_Vs11.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IPVC_Escuta_Vs11.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IPVC_Escuta_Vs11.Models.ComentarioS", b =>
                {
                    b.Property<int>("IDComentarioS")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDComentarioS"));

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Hora")
                        .HasColumnType("time");

                    b.Property<int>("IDReclamacaoSugestao")
                        .HasColumnType("int");

                    b.Property<int>("ReclamacaoSugestaoIDReclamacaoSugestao")
                        .HasColumnType("int");

                    b.HasKey("IDComentarioS");

                    b.HasIndex("ReclamacaoSugestaoIDReclamacaoSugestao");

                    b.ToTable("ComentariosS");
                });

            modelBuilder.Entity("IPVC_Escuta_Vs11.Models.DenunciaR", b =>
                {
                    b.Property<int>("IDDenunciaR")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDDenunciaR"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Hora")
                        .HasColumnType("time");

                    b.Property<int>("IDReclamacaoSugestao")
                        .HasColumnType("int");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReclamacaoSugestaoIDReclamacaoSugestao")
                        .HasColumnType("int");

                    b.HasKey("IDDenunciaR");

                    b.HasIndex("ReclamacaoSugestaoIDReclamacaoSugestao");

                    b.ToTable("DenunciasR");
                });

            modelBuilder.Entity("IPVC_Escuta_Vs11.Models.Elogios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Avaliacao")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IDReclamacaoSugestao")
                        .HasColumnType("int");

                    b.Property<string>("Opiniao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("ReclamacaoSugestaoIDReclamacaoSugestao")
                        .HasColumnType("int");

                    b.Property<int>("TipoVisualizacao")
                        .HasColumnType("int");

                    b.Property<string>("UtilizadorId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReclamacaoSugestaoIDReclamacaoSugestao");

                    b.ToTable("Elogios");
                });

            modelBuilder.Entity("IPVC_Escuta_Vs11.Models.Estado", b =>
                {
                    b.Property<int>("IDEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDEstado"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDEstado");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("IPVC_Escuta_Vs11.Models.EstadoRS", b =>
                {
                    b.Property<int>("IDEstadoRS")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDEstadoRS"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("EstadoIDEstado")
                        .HasColumnType("int");

                    b.Property<int>("IDEstado")
                        .HasColumnType("int");

                    b.Property<int>("IDReclamacaoSugestao")
                        .HasColumnType("int");

                    b.Property<int>("ReclamacaoSugestaoIDReclamacaoSugestao")
                        .HasColumnType("int");

                    b.HasKey("IDEstadoRS");

                    b.HasIndex("EstadoIDEstado");

                    b.HasIndex("ReclamacaoSugestaoIDReclamacaoSugestao");

                    b.ToTable("EstadosRS");
                });

            modelBuilder.Entity("IPVC_Escuta_Vs11.Models.ReclamacaoSugestao", b =>
                {
                    b.Property<int>("IDReclamacaoSugestao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDReclamacaoSugestao"));

                    b.Property<int>("Categoria")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescricaoRec")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Escola")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Hora")
                        .HasColumnType("time");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("TipoFormulario")
                        .HasColumnType("int");

                    b.Property<string>("UtilizadorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IDReclamacaoSugestao");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("ReclamacoesSugestoes");
                });

            modelBuilder.Entity("IPVC_Escuta_Vs11.Models.RespostaR", b =>
                {
                    b.Property<int>("IDRespostaR")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDRespostaR"));

                    b.Property<int>("IDReclamacaoSugestao")
                        .HasColumnType("int");

                    b.Property<int>("ReclamacaoSugestaoIDReclamacaoSugestao")
                        .HasColumnType("int");

                    b.Property<string>("Resposta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDRespostaR");

                    b.HasIndex("ReclamacaoSugestaoIDReclamacaoSugestao");

                    b.ToTable("RespostasR");
                });

            modelBuilder.Entity("IPVC_Escuta_Vs11.Models.Utilizador", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Regist_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("IPVC_Escuta_Vs11.Models.ComentarioS", b =>
                {
                    b.HasOne("IPVC_Escuta_Vs11.Models.ReclamacaoSugestao", "ReclamacaoSugestao")
                        .WithMany("Comentarios")
                        .HasForeignKey("ReclamacaoSugestaoIDReclamacaoSugestao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReclamacaoSugestao");
                });

            modelBuilder.Entity("IPVC_Escuta_Vs11.Models.DenunciaR", b =>
                {
                    b.HasOne("IPVC_Escuta_Vs11.Models.ReclamacaoSugestao", "ReclamacaoSugestao")
                        .WithMany("Denuncias")
                        .HasForeignKey("ReclamacaoSugestaoIDReclamacaoSugestao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReclamacaoSugestao");
                });

            modelBuilder.Entity("IPVC_Escuta_Vs11.Models.Elogios", b =>
                {
                    b.HasOne("IPVC_Escuta_Vs11.Models.ReclamacaoSugestao", null)
                        .WithMany("Elogios")
                        .HasForeignKey("ReclamacaoSugestaoIDReclamacaoSugestao");
                });

            modelBuilder.Entity("IPVC_Escuta_Vs11.Models.EstadoRS", b =>
                {
                    b.HasOne("IPVC_Escuta_Vs11.Models.Estado", "Estado")
                        .WithMany("EstadoRS")
                        .HasForeignKey("EstadoIDEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IPVC_Escuta_Vs11.Models.ReclamacaoSugestao", "ReclamacaoSugestao")
                        .WithMany()
                        .HasForeignKey("ReclamacaoSugestaoIDReclamacaoSugestao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");

                    b.Navigation("ReclamacaoSugestao");
                });

            modelBuilder.Entity("IPVC_Escuta_Vs11.Models.ReclamacaoSugestao", b =>
                {
                    b.HasOne("IPVC_Escuta_Vs11.Models.Utilizador", "Utilizador")
                        .WithMany("ReclamacoesSugestoes")
                        .HasForeignKey("UtilizadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("IPVC_Escuta_Vs11.Models.RespostaR", b =>
                {
                    b.HasOne("IPVC_Escuta_Vs11.Models.ReclamacaoSugestao", "ReclamacaoSugestao")
                        .WithMany()
                        .HasForeignKey("ReclamacaoSugestaoIDReclamacaoSugestao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReclamacaoSugestao");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("IPVC_Escuta_Vs11.Models.Utilizador", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("IPVC_Escuta_Vs11.Models.Utilizador", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IPVC_Escuta_Vs11.Models.Utilizador", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("IPVC_Escuta_Vs11.Models.Utilizador", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IPVC_Escuta_Vs11.Models.Estado", b =>
                {
                    b.Navigation("EstadoRS");
                });

            modelBuilder.Entity("IPVC_Escuta_Vs11.Models.ReclamacaoSugestao", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("Denuncias");

                    b.Navigation("Elogios");
                });

            modelBuilder.Entity("IPVC_Escuta_Vs11.Models.Utilizador", b =>
                {
                    b.Navigation("ReclamacoesSugestoes");
                });
#pragma warning restore 612, 618
        }
    }
}
