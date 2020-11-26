using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Flotte.Web.Locomotives
{
    public static class DbLocomotives
    {
        public static void InitLocomotives(this MigrationBuilder migrationBuilder)
        {
            var locomotives =
                new[]
                {
                    new Locomotive {Marque = "MegaLoco", Modele = "Puissance Loco", TractionMax = 500},
                    new Locomotive {Marque = "MegaLoco", Modele = "Loco mini", TractionMax = 200},
                    new Locomotive {Marque = "Loco-st", Modele = "Loco micro", TractionMax = 50},
                };

            var initLocomotivesSql =
                $"INSERT INTO Locomotives(Id, Marque, Modele, TractionMax) " +
                string.Join(
                    " UNION ALL ",
                    locomotives.Select(l => $"SELECT '{Guid.NewGuid()}', '{l.Marque}', '{l.Modele}', {l.TractionMax}"));

            migrationBuilder.Sql(initLocomotivesSql);
        }
    }
}