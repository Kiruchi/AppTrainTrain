using System.Threading.Tasks;

namespace Reservations.Hexagon.SecondaryPorts
{
    public interface IReservationNotifieur
    {
        Task NotifierReservationValideeAsync(Reservation reservation);
    }
}