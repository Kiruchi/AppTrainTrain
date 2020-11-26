using System;

namespace Voyages.Hexagon
{
    public class Voiture
    {
        public Voiture(int numero, Guid wagonId, int capacite)
        {
            Numero = numero;
            WagonId = wagonId;
            Capacite = capacite;
        }

        public int Numero { get; }
        public Guid WagonId { get; }
        public int Capacite { get; }
    }
}