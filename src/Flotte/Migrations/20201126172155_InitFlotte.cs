using System;
using System.Linq;
using Flotte.Web.Locomotives;
using Flotte.Web.Wagons;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Flotte.Web.Migrations
{
    public partial class InitFlotte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locomotives",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Marque = table.Column<string>(nullable: false),
                    Modele = table.Column<string>(nullable: false),
                    TractionMax = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locomotives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wagons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Marque = table.Column<string>(nullable: false),
                    Modele = table.Column<string>(nullable: false),
                    Poids = table.Column<decimal>(nullable: false),
                    Capacite = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wagons", x => x.Id);
                });
            //
            migrationBuilder.InitLocomotives();
            migrationBuilder.InitWagons();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locomotives");

            migrationBuilder.DropTable(
                name: "Wagons");
        }
    }
}
