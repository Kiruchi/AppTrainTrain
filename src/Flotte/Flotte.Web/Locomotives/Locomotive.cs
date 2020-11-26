using System;

namespace Flotte.Web.Locomotives
{
    public class Locomotive
    {
        public Guid Id { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public decimal TractionMax { get; set; }
    }
}