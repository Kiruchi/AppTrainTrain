using System;
using Reservations.Hexagon;

namespace Reservations.Web.Controllers
{
    public class PassagerDto
    {
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public DateTime DateDeNaissance { get; set; }

        public string Email { get; set; }

        public Passager ToDomain() =>
            new Passager(
                Nom,
                Prenom,
                DateDeNaissance,
                new Email(Email));
    }
}