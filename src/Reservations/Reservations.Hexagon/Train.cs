using System.Collections.Generic;

namespace Reservations.Hexagon
{
    public class Train
    {
        public IReadOnlyCollection<Voiture> Voitures { get; }

        public Train()
        {
            Voitures = new List<Voiture>();
        }
    }
}