using System.Collections.Generic;

namespace Reservations.Hexagon
{
    public class Train
    {
        public IReadOnlyCollection<Voiture> Voitures { get; set; } =
            new List<Voiture>();
    }
}