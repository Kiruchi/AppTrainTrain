using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reservations.Hexagon.PrimaryPorts
{
    interface IReservationPrimaryPort
    {
        Task ReserverAsync(int idVoyage, IReadOnlyCollection<Passager> passagers);
    }
}
