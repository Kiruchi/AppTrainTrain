using System.Collections.Generic;

namespace Reservations.Web.Controllers
{
    public class DemandeReservationDto
    {
        public int IdVoyage { get; set; }
        public IReadOnlyCollection<PassagerDto> Passagers { get; set; }
    }
}