using System;
using System.Collections.Generic;
using System.Linq;

namespace Reservations.Hexagon
{
    public class Train
    {
        public Train(int idVoyage, IReadOnlyCollection<Voiture> voitures)
        {
            IdVoyage = idVoyage;
            Voitures = voitures;
        }

        public int IdVoyage { get; }
        public IReadOnlyCollection<Voiture> Voitures { get; }

        public bool PeutReserver(int nbPassagers, decimal seuilCapacite) =>
            Voitures.Any(v => v.PeutReserver(nbPassagers, seuilCapacite));

        public Reservation Reserver(IReadOnlyCollection<Passager> passagers, decimal seuilCapacite)
        {
            if (!PeutReserver(passagers.Count, seuilCapacite))
                throw new ArgumentException("train plein");
                
            var voitureAvecDeLaPlace =
                Voitures.First(v => v.PeutReserver(passagers.Count, seuilCapacite));

            voitureAvecDeLaPlace.Reserver(passagers.Count, seuilCapacite);

            return new Reservation(IdVoyage, passagers, voitureAvecDeLaPlace.Numero);
        }
    }
}