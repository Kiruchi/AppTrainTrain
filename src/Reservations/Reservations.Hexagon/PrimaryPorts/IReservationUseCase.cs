using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reservations.Hexagon.PrimaryPorts
{
    public interface IReservationUseCase
    {
        Task ReserverAsync(int idVoyage, IReadOnlyCollection<Passager> passagers);
    }
}