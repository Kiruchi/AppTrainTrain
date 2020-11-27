using System.Collections.Generic;

namespace Reservations.Hexagon
{
    public class Reservation
    {
        public Reservation(IdVoyage idVoyage, IReadOnlyCollection<Passager> passagers, NumeroVoiture numeroVoiture)
        {
            IdVoyage = idVoyage;
            Passagers = passagers;
            NumeroVoiture = numeroVoiture;
        }

        public IdVoyage IdVoyage { get; }

        public IReadOnlyCollection<Passager> Passagers { get; }

        public NumeroVoiture NumeroVoiture { get; }
    }
}