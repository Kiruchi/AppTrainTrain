using System.Threading.Tasks;
using Reservations.Hexagon;
using Reservations.Hexagon.SecondaryPorts;

namespace Reservations.Infra
{
    public class DummyReservationRepository : IReservationRepository
    {
        public async Task SaveAsync(Reservation reservation)
        {
            await Task.CompletedTask;
        }
    }
}