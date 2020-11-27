using System.Collections.Generic;
using System.Linq;
using Reservations.Hexagon;

namespace Reservations.Infra.Db.Models
{
    public class DbReservation
    {
        public static DbReservation FromDomain(Reservation reservation) =>
            new DbReservation
            {
                IdVoyage = (int)reservation.IdVoyage,
                NumeroVoiture = (int)reservation.NumeroVoiture,
                Passagers =
                    reservation.Passagers
                        .Select(p => DbPassager.FromDomain(p))
                        .ToList()
            };

        public int Id { get; set; }
        public int IdVoyage { get; set; }
        public int NumeroVoiture { get; set; }
        public IReadOnlyCollection<DbPassager> Passagers { get; set; }
    }
}