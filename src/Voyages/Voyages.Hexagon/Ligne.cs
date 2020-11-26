using System;

namespace Voyages.Hexagon
{
    public class Ligne
    {
        public Ligne(int id, Gare depart, Gare arrivee, TimeSpan duree)
        {
            Id = id;
            Depart = depart;
            Arrivee = arrivee;
            Duree = duree;
        }

        public int Id { get; }
        public Gare Depart { get; }
        public Gare Arrivee { get; }
        public TimeSpan Duree { get; }
        
    }
}