using Microsoft.EntityFrameworkCore.Migrations;
using Reseau.Web.Gares;
using Reseau.Web.Lignes;

namespace Reseau.Web.Migrations
{
    public partial class InitReseau : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gares",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: false),
                    NumeroRue = table.Column<int>(nullable: true),
                    Rue = table.Column<string>(nullable: false),
                    CodePostal = table.Column<string>(nullable: false),
                    Ville = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lignes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GareDepartId = table.Column<int>(nullable: false),
                    GareArriveeId = table.Column<int>(nullable: false),
                    DureeTrajet = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lignes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lignes_Gares_GareArriveeId",
                        column: x => x.GareArriveeId,
                        principalTable: "Gares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Lignes_Gares_GareDepartId",
                        column: x => x.GareDepartId,
                        principalTable: "Gares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lignes_GareArriveeId",
                table: "Lignes",
                column: "GareArriveeId");

            migrationBuilder.CreateIndex(
                name: "IX_Lignes_GareDepartId",
                table: "Lignes",
                column: "GareDepartId");
            
            migrationBuilder.InitGares();
            migrationBuilder.InitLignes();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lignes");

            migrationBuilder.DropTable(
                name: "Gares");
        }
    }
}
