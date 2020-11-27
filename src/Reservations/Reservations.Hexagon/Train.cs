using System;
using System.Collections.Generic;
using System.Linq;
using Reservations.Hexagon.Exceptions;

namespace Reservations.Hexagon
{
    public class Train
    {
        public Train(IdVoyage idVoyage, IReadOnlyCollection<Voiture> voitures)
        {
            IdVoyage = idVoyage;
            Voitures = voitures;
        }

        public IdVoyage IdVoyage { get; }
        public IReadOnlyCollection<Voiture> Voitures { get; }

        public bool PeutReserver(int nbPassagers, TauxOccupation seuilCapacite) =>
            Voitures.Any(v => v.PeutReserver(nbPassagers, seuilCapacite));

        public Reservation Reserver(IReadOnlyCollection<Passager> passagers, TauxOccupation seuilCapacite)
        {
            if (!PeutReserver(passagers.Count, seuilCapacite))
                throw new TrainPleinException();
                
            var voitureAvecDeLaPlace =
                Voitures.First(v => v.PeutReserver(passagers.Count, seuilCapacite));

            voitureAvecDeLaPlace.Reserver(passagers.Count, seuilCapacite);

            return new Reservation(IdVoyage, passagers, voitureAvecDeLaPlace.Numero);
        }
    }
}