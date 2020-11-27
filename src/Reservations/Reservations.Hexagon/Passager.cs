using System;

namespace Reservations.Hexagon
{
    public class Passager
    {
        public string Nom { get; }
        public string Prenom { get; }
        public DateTime DateDeNaissance { get; }
        public string Email { get; }

        public Passager(string nom, string prenom, DateTime dateDeNaissance, string email)
        {
            Nom = nom;
            Prenom = prenom;
            DateDeNaissance = dateDeNaissance;
            Email = email;
        }
    }
}