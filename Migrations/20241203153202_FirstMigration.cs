using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPVC_Escuta_Vs11.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Regist_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    IDEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.IDEstado);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReclamacoesSugestoes",
                columns: table => new
                {
                    IDReclamacaoSugestao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoFormulario = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora = table.Column<TimeSpan>(type: "time", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DescricaoRec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<int>(type: "int", nullable: false),
                    Escola = table.Column<int>(type: "int", nullable: false),
                    UtilizadorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UtilizadorId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReclamacoesSugestoes", x => x.IDReclamacaoSugestao);
                    table.ForeignKey(
                        name: "FK_ReclamacoesSugestoes_AspNetUsers_UtilizadorId",
                        column: x => x.UtilizadorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReclamacoesSugestoes_AspNetUsers_UtilizadorId1",
                        column: x => x.UtilizadorId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComentariosS",
                columns: table => new
                {
                    IDComentarioS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDReclamacaoSugestao = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora = table.Column<TimeSpan>(type: "time", nullable: false),
                    ReclamacaoSugestaoIDReclamacaoSugestao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentariosS", x => x.IDComentarioS);
                    table.ForeignKey(
                        name: "FK_ComentariosS_ReclamacoesSugestoes_ReclamacaoSugestaoIDReclamacaoSugestao",
                        column: x => x.ReclamacaoSugestaoIDReclamacaoSugestao,
                        principalTable: "ReclamacoesSugestoes",
                        principalColumn: "IDReclamacaoSugestao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DenunciasR",
                columns: table => new
                {
                    IDDenunciaR = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDReclamacaoSugestao = table.Column<int>(type: "int", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora = table.Column<TimeSpan>(type: "time", nullable: false),
                    ReclamacaoSugestaoIDReclamacaoSugestao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DenunciasR", x => x.IDDenunciaR);
                    table.ForeignKey(
                        name: "FK_DenunciasR_ReclamacoesSugestoes_ReclamacaoSugestaoIDReclamacaoSugestao",
                        column: x => x.ReclamacaoSugestaoIDReclamacaoSugestao,
                        principalTable: "ReclamacoesSugestoes",
                        principalColumn: "IDReclamacaoSugestao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Elogios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opiniao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Avaliacao = table.Column<int>(type: "int", nullable: false),
                    TipoVisualizacao = table.Column<int>(type: "int", nullable: false),
                    IDReclamacaoSugestao = table.Column<int>(type: "int", nullable: true),
                    UtilizadorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReclamacaoSugestaoIDReclamacaoSugestao = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elogios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elogios_ReclamacoesSugestoes_ReclamacaoSugestaoIDReclamacaoSugestao",
                        column: x => x.ReclamacaoSugestaoIDReclamacaoSugestao,
                        principalTable: "ReclamacoesSugestoes",
                        principalColumn: "IDReclamacaoSugestao");
                });

            migrationBuilder.CreateTable(
                name: "EstadosRS",
                columns: table => new
                {
                    IDEstadoRS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDEstado = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoIDEstado = table.Column<int>(type: "int", nullable: false),
                    IDReclamacaoSugestao = table.Column<int>(type: "int", nullable: false),
                    ReclamacaoSugestaoIDReclamacaoSugestao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosRS", x => x.IDEstadoRS);
                    table.ForeignKey(
                        name: "FK_EstadosRS_Estados_EstadoIDEstado",
                        column: x => x.EstadoIDEstado,
                        principalTable: "Estados",
                        principalColumn: "IDEstado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstadosRS_ReclamacoesSugestoes_ReclamacaoSugestaoIDReclamacaoSugestao",
                        column: x => x.ReclamacaoSugestaoIDReclamacaoSugestao,
                        principalTable: "ReclamacoesSugestoes",
                        principalColumn: "IDReclamacaoSugestao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RespostasR",
                columns: table => new
                {
                    IDRespostaR = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDReclamacaoSugestao = table.Column<int>(type: "int", nullable: false),
                    Resposta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReclamacaoSugestaoIDReclamacaoSugestao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespostasR", x => x.IDRespostaR);
                    table.ForeignKey(
                        name: "FK_RespostasR_ReclamacoesSugestoes_ReclamacaoSugestaoIDReclamacaoSugestao",
                        column: x => x.ReclamacaoSugestaoIDReclamacaoSugestao,
                        principalTable: "ReclamacoesSugestoes",
                        principalColumn: "IDReclamacaoSugestao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ComentariosS_ReclamacaoSugestaoIDReclamacaoSugestao",
                table: "ComentariosS",
                column: "ReclamacaoSugestaoIDReclamacaoSugestao");

            migrationBuilder.CreateIndex(
                name: "IX_DenunciasR_ReclamacaoSugestaoIDReclamacaoSugestao",
                table: "DenunciasR",
                column: "ReclamacaoSugestaoIDReclamacaoSugestao");

            migrationBuilder.CreateIndex(
                name: "IX_Elogios_ReclamacaoSugestaoIDReclamacaoSugestao",
                table: "Elogios",
                column: "ReclamacaoSugestaoIDReclamacaoSugestao");

            migrationBuilder.CreateIndex(
                name: "IX_EstadosRS_EstadoIDEstado",
                table: "EstadosRS",
                column: "EstadoIDEstado");

            migrationBuilder.CreateIndex(
                name: "IX_EstadosRS_ReclamacaoSugestaoIDReclamacaoSugestao",
                table: "EstadosRS",
                column: "ReclamacaoSugestaoIDReclamacaoSugestao");

            migrationBuilder.CreateIndex(
                name: "IX_ReclamacoesSugestoes_UtilizadorId",
                table: "ReclamacoesSugestoes",
                column: "UtilizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_ReclamacoesSugestoes_UtilizadorId1",
                table: "ReclamacoesSugestoes",
                column: "UtilizadorId1");

            migrationBuilder.CreateIndex(
                name: "IX_RespostasR_ReclamacaoSugestaoIDReclamacaoSugestao",
                table: "RespostasR",
                column: "ReclamacaoSugestaoIDReclamacaoSugestao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ComentariosS");

            migrationBuilder.DropTable(
                name: "DenunciasR");

            migrationBuilder.DropTable(
                name: "Elogios");

            migrationBuilder.DropTable(
                name: "EstadosRS");

            migrationBuilder.DropTable(
                name: "RespostasR");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "ReclamacoesSugestoes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
