using System;

namespace Reseau.Web.Gares
{
    public class Gare
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int? NumeroRue { get; set; }
        public string Rue { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
    }
}