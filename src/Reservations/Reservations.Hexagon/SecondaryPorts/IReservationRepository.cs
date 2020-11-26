using System.Threading.Tasks;

namespace Reservations.Hexagon.SecondaryPorts
{
    public interface IReservationRepository
    {
        Task SaveAsync(Reservation reservation);
    }
}