using System;
using Reservations.Hexagon.Exceptions;
using Shared.Core.DomainModeling;

namespace Reservations.Hexagon
{
    public class Email : StringBasedValueObject
    {
        public Email(string email) : base(email)
        {
            if (!email.Contains("@"))
                throw new EmailInvalideException();
        }
    }

    public class Passager
    {
        public Passager(string nom, string prenom, DateTime dateTime, Email email)
        {
            Nom = nom;
            Prenom = prenom;
            DateTime = dateTime;
            Email = email;
        }

        public string Nom { get; }
        public string Prenom { get; }
        public DateTime DateTime { get; }
        public Email Email { get; }
    }
}