using System.Threading.Tasks;

namespace Voyages.Hexagon.UseCases
{
    public interface IVoyageRepository
    {
        Task<Voyage?> GetVoyageAsync(int voyageId);
    }
}