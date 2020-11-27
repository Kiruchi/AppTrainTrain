using System.Threading.Tasks;

namespace Reservations.Hexagon.SecondaryPorts
{
    public interface ITrainRepository
    {
        Task<Train?> GetTrainDuVoyageAsync(int idVoyage);
        Task SaveAsync(Train train);
    }
}
