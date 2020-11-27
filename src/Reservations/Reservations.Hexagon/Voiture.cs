using System;
using Reservations.Hexagon.Exceptions;
using Shared.Core.DomainModeling;

namespace Reservations.Hexagon
{
    public class NumeroVoiture : Id<int>
    {
        public NumeroVoiture(int internalValue) : base(internalValue) { }
    }
    
    public class Voiture
    {
        public Voiture(NumeroVoiture numero, int capacite, int placesOccupees = 0)
        {
            Numero = numero;
            Capacite = capacite;
            PlacesOccupees = placesOccupees;
        }

        public NumeroVoiture Numero { get; }
        public int Capacite { get; }
        public int PlacesOccupees { get; private set; }

        public bool PeutReserver(int nbPassagers, TauxOccupation seuilCapacite) =>
            PlacesOccupees + nbPassagers < Capacite * (decimal)seuilCapacite;

        public void Reserver(int nbPassagers, TauxOccupation seuilCapacite)
        {
            if (!PeutReserver(nbPassagers, seuilCapacite))
                throw new VoiturePleineException(Numero);

            PlacesOccupees += nbPassagers;
        }
    }
}