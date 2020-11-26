using System;

namespace Flotte.Web.Wagons
{
    public class Wagon
    {
        public Guid Id { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public decimal Poids { get; set; }
        public int Capacite { get; set; }
        
    }
}