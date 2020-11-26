using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Migrations;
using Reseau.Web.Gares;

namespace Reseau.Web.Lignes
{
    public static class DbLignes
    {
        public static void InitLignes(this MigrationBuilder migrationBuilder)
        {
            var lignes =
                new[]
                {
                    new Ligne { GareDepartId = DbGares.NantesId, GareArriveeId = DbGares.MontparnasseId, DureeTrajet = 130 },
                    new Ligne { GareDepartId = DbGares.MontparnasseId, GareArriveeId = DbGares.NantesId, DureeTrajet = 130 },
                };

            var initLocomotivesSql =
                $"INSERT INTO Lignes(GareDepartId, GareArriveeId, DureeTrajet) " +
                string.Join(
                    " UNION ALL ",
                    lignes.Select(l => $"SELECT '{l.GareDepartId}', '{l.GareArriveeId}', {l.DureeTrajet}"));

            migrationBuilder.Sql(initLocomotivesSql);
        }
    }
}