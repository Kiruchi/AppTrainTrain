using System;
using Reservations.Hexagon;

namespace Reservations.Infra.Db.Models
{
    public class DbPassager
    {
        public Guid Id { get; set; }
        public int ReservationId { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public string Email { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }

        public static DbPassager FromDomain(Passager passager) =>
            new DbPassager
            {
                Id = Guid.NewGuid(),
                Nom = passager.Nom,
                Prenom = passager.Prenom,
                Email = (string)passager.Email,
                DateDeNaissance = passager.DateDeNaissance
            };
    }
}