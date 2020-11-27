using Reservations.Hexagon.PrimaryPorts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reservations.Hexagon.UseCases
{
    public class ReservationUseCase : IReservationPrimaryPort
    {
        public Task ReserverAsync(int idVoyage, IReadOnlyCollection<Passager> passagers)
        {
            throw new System.NotImplementedException();
        }
    }
}
