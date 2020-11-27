using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservations.Infra.Migrations
{
    public partial class InitReservations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVoyage = table.Column<int>(nullable: false),
                    NumeroVoiture = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passagers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ReservationId = table.Column<int>(nullable: false),
                    DateDeNaissance = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Prenom = table.Column<string>(nullable: false),
                    Nom = table.Column<string>(nullable: false),
                    DbReservationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passagers_Reservations_DbReservationId",
                        column: x => x.DbReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Passagers_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passagers_DbReservationId",
                table: "Passagers",
                column: "DbReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Passagers_ReservationId",
                table: "Passagers",
                column: "ReservationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passagers");

            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
