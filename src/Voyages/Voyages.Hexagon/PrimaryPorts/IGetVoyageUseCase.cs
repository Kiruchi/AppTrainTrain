using System.Threading.Tasks;

namespace Voyages.Hexagon.PrimaryPorts
{
    public interface IGetVoyageUseCase
    {
        Task<Voyage?> GetVoyageAsync(int voyageId);
    }
}