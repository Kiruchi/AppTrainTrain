using System.Collections.Generic;

namespace Reservations.Hexagon
{
    public class Reservation
    {
        public Reservation(int idVoyage, IReadOnlyCollection<Passager> passagers, int numeroVoiture)
        {
            IdVoyage = idVoyage;
            Passagers = passagers;
            NumeroVoiture = numeroVoiture;
        }

        public int IdVoyage { get; }

        public IReadOnlyCollection<Passager> Passagers { get; }

        public int NumeroVoiture { get; }
    }
}