using System.Linq;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reseau.Web.Gares
{
    public static class DbGares
    {
        public const int NantesId = 1;
        public const int MontparnasseId = 2;
        public static void InitGares(this MigrationBuilder migrationBuilder)
        {
            var gares =
                new[]
                {
                    new Gare {Nom = "Nantes nord", NumeroRue = 12, Rue = "rue de la gare", CodePostal = "44000", Ville = "Nantes"},
                    new Gare {Nom = "Montparnasse", NumeroRue = 2, Rue = "chemin de Montparnasse", CodePostal = "75000", Ville = "Paris"},
                };

            var initGaresSql =
                $"INSERT INTO Gares(Nom, NumeroRue, Rue, CodePostal, Ville) " +
                string.Join(
                    " UNION ALL ",
                    gares.Select(l => $"SELECT '{l.Nom}', {l.NumeroRue}, '{l.Rue}', '{l.CodePostal}', '{l.Ville}'"));

            migrationBuilder.Sql(initGaresSql);
        }
    }
}