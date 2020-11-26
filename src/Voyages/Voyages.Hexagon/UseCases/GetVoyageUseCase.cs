using System.Threading.Tasks;
using Voyages.Hexagon.PrimaryPorts;

namespace Voyages.Hexagon.UseCases
{
    public class GetVoyageUseCase : IGetVoyageUseCase
    {
        private readonly IVoyageRepository _repository;

        public GetVoyageUseCase(IVoyageRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Voyage?> GetVoyageAsync(int voyageId)
        {
            return await _repository.GetVoyageAsync(voyageId);
        }
    }
}