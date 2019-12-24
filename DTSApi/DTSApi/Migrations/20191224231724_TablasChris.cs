using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DTSApi.Migrations
{
    public partial class TablasChris : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Esquemas",
                columns: table => new
                {
                    Secuencia = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Esquemas", x => x.Secuencia);
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    Secuencia = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(nullable: false),
                    PermiteEditar = table.Column<bool>(nullable: false),
                    PermiteVista = table.Column<bool>(nullable: false),
                    PermiteEjecucion = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.Secuencia);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Secuencia = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Secuencia);
                });

            migrationBuilder.CreateTable(
                name: "TipoPantallas",
                columns: table => new
                {
                    Secuencia = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPantallas", x => x.Secuencia);
                });

            migrationBuilder.CreateTable(
                name: "RolesEsquemas",
                columns: table => new
                {
                    Secuencia = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SecuenciaPermiso = table.Column<int>(nullable: false),
                    PermisosSecuencia = table.Column<int>(nullable: true),
                    SecuenciaEsquemas = table.Column<int>(nullable: false),
                    EsquemasSecuencia = table.Column<int>(nullable: true),
                    SecuenciaRol = table.Column<int>(nullable: false),
                    RolSecuencia = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesEsquemas", x => x.Secuencia);
                    table.ForeignKey(
                        name: "FK_RolesEsquemas_Esquemas_EsquemasSecuencia",
                        column: x => x.EsquemasSecuencia,
                        principalTable: "Esquemas",
                        principalColumn: "Secuencia",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolesEsquemas_Permisos_PermisosSecuencia",
                        column: x => x.PermisosSecuencia,
                        principalTable: "Permisos",
                        principalColumn: "Secuencia",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolesEsquemas_Rol_RolSecuencia",
                        column: x => x.RolSecuencia,
                        principalTable: "Rol",
                        principalColumn: "Secuencia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pantallas",
                columns: table => new
                {
                    Secuencia = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(nullable: false),
                    SecuenciaTipoPantalla = table.Column<int>(nullable: false),
                    TipoPantallaSecuencia = table.Column<int>(nullable: true),
                    SecuenciaEsquemas = table.Column<int>(nullable: false),
                    EsquemasSecuencia = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pantallas", x => x.Secuencia);
                    table.ForeignKey(
                        name: "FK_Pantallas_Esquemas_EsquemasSecuencia",
                        column: x => x.EsquemasSecuencia,
                        principalTable: "Esquemas",
                        principalColumn: "Secuencia",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pantallas_TipoPantallas_TipoPantallaSecuencia",
                        column: x => x.TipoPantallaSecuencia,
                        principalTable: "TipoPantallas",
                        principalColumn: "Secuencia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pantallas_EsquemasSecuencia",
                table: "Pantallas",
                column: "EsquemasSecuencia");

            migrationBuilder.CreateIndex(
                name: "IX_Pantallas_TipoPantallaSecuencia",
                table: "Pantallas",
                column: "TipoPantallaSecuencia");

            migrationBuilder.CreateIndex(
                name: "IX_RolesEsquemas_EsquemasSecuencia",
                table: "RolesEsquemas",
                column: "EsquemasSecuencia");

            migrationBuilder.CreateIndex(
                name: "IX_RolesEsquemas_PermisosSecuencia",
                table: "RolesEsquemas",
                column: "PermisosSecuencia");

            migrationBuilder.CreateIndex(
                name: "IX_RolesEsquemas_RolSecuencia",
                table: "RolesEsquemas",
                column: "RolSecuencia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pantallas");

            migrationBuilder.DropTable(
                name: "RolesEsquemas");

            migrationBuilder.DropTable(
                name: "TipoPantallas");

            migrationBuilder.DropTable(
                name: "Esquemas");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
