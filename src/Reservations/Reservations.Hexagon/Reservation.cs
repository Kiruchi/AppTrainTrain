using System.Collections.Generic;

namespace Reservations.Hexagon
{
    public class Reservation
    {
        public int IdVoyage { get; set; }
        public IReadOnlyCollection<Passager> Passagers { get; set; }
        public int NumeroVoiture { get; set; }
    }
}