using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Voyages.Hexagon.PrimaryPorts;

namespace Voyages.Web
{
    [ApiController]
    [Route("voyages")]
    public class VoyagesController : ControllerBase
    {
        private readonly IGetVoyageUseCase _useCase;

        public VoyagesController(IGetVoyageUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var voyage = await _useCase.GetVoyageAsync(id);
            return Ok(voyage);
        }
    }
}