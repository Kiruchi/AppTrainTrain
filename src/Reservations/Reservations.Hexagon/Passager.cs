using System;

namespace Reservations.Hexagon
{
    public class Passager
    {
        public Passager(string nom, string prenom, DateTime dateTime, string email)
        {
            Nom = nom;
            Prenom = prenom;
            DateTime = dateTime;
            Email = email;
        }

        public string Nom { get; }
        public string Prenom { get; }
        public DateTime DateTime { get; }
        public string Email { get; }
    }
}