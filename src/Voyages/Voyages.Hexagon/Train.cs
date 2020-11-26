using System;
using System.Collections.Generic;

namespace Voyages.Hexagon
{
    public class Train
    {
        public Train(Guid id, Guid locomotiveId, IReadOnlyCollection<Voiture> voitures)
        {
            Id = id;
            LocomotiveId = locomotiveId;
            Voitures = voitures;
        }

        public Guid Id { get; }
        public Guid LocomotiveId { get; }
        public IReadOnlyCollection<Voiture> Voitures { get; }
    }
}