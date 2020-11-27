using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reservations.Hexagon.PrimaryPorts
{
    public interface IReservationUseCase
    {
        Task ReserverAsync(IdVoyage idVoyage, IReadOnlyCollection<Passager> passagers);
    }
}