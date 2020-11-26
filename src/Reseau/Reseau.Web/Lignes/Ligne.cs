using System;
using Reseau.Web.Gares;

namespace Reseau.Web.Lignes
{
    public class Ligne
    {
        public int Id { get; set; }
        
        public int GareDepartId { get; set; }
        public Gare GareDepart { get; set; }
        public int GareArriveeId { get; set; }
        public Gare GareArrivee { get; set; }
        public int DureeTrajet { get; set; }
    }
}