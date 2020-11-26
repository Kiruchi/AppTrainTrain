using System;

namespace Reservations.Hexagon
{
    public class Voiture
    {
        public Voiture(int numero, int capacite, int placesOccupees)
        {
            Numero = numero;
            Capacite = capacite;
            PlacesOccupees = placesOccupees;
        }

        public int Numero { get; }
        public int Capacite { get; }
        public int PlacesOccupees { get; private set; }

        public bool PeutReserver(int nbPassagers, decimal seuilCapacite) =>
            PlacesOccupees + nbPassagers < Capacite * seuilCapacite;

        public void Reserver(int nbPassagers, decimal seuilCapacite)
        {
            if (!PeutReserver(nbPassagers, seuilCapacite))
                throw new InvalidOperationException($"Voiture {Numero} pleine");

            PlacesOccupees += nbPassagers;
        }
    }
}