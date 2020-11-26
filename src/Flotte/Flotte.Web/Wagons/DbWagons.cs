using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Flotte.Web.Wagons
{
    public static class DbWagons
    {
        public static void InitWagons(this MigrationBuilder migrationBuilder)
        {
            var wagons =
                new[]
                {
                    new Wagon {Marque = "SuperWagon", Modele = "Wag Simple", Capacite = 100, Poids = 13},
                    new Wagon {Marque = "SuperWagon", Modele = "Wag Double", Capacite = 200, Poids = 17},
                    new Wagon {Marque = "LuxeWagon", Modele = "Wag Elite", Capacite = 50, Poids = 10},
                    new Wagon {Marque = "SuperWagon", Modele = "Wag Simple", Capacite = 100, Poids = 13},
                    new Wagon {Marque = "SuperWagon", Modele = "Wag Double", Capacite = 200, Poids = 17},
                    new Wagon {Marque = "LuxeWagon", Modele = "Wag Elite", Capacite = 50, Poids = 10},
                    new Wagon {Marque = "SuperWagon", Modele = "Wag Simple", Capacite = 100, Poids = 13},
                    new Wagon {Marque = "SuperWagon", Modele = "Wag Double", Capacite = 200, Poids = 17},
                    new Wagon {Marque = "LuxeWagon", Modele = "Wag Elite", Capacite = 50, Poids = 10},
                    new Wagon {Marque = "SuperWagon", Modele = "Wag Simple", Capacite = 100, Poids = 13},
                    new Wagon {Marque = "SuperWagon", Modele = "Wag Double", Capacite = 200, Poids = 17},
                    new Wagon {Marque = "LuxeWagon", Modele = "Wag Elite", Capacite = 50, Poids = 10},
                };
            
            var initWagonsSql =
                $"INSERT INTO Wagons(Id, Marque, Modele, Capacite, Poids) " +
                string.Join(
                    " UNION ALL ",
                    wagons.Select(w => $"SELECT '{Guid.NewGuid()}', '{w.Marque}', '{w.Modele}', {w.Capacite}, {w.Poids}"));

            migrationBuilder.Sql(initWagonsSql);
        }
    }
}