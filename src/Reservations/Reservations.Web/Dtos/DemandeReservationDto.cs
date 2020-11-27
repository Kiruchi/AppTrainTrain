using System.Collections.Generic;

namespace Reservations.Web.Dtos
{
    public class DemandeReservationDto
    {
        public int IdVoyage { get; set; }
        public IReadOnlyCollection<PassagerDto> Passagers { get; set; }
    }
}