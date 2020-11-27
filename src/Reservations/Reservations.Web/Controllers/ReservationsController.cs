using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reservations.Hexagon;
using Reservations.Hexagon.Exceptions;
using Reservations.Hexagon.PrimaryPorts;
using Reservations.Web.Dtos;

namespace Reservations.Web.Controllers
{
    [ApiController]
    [Route("reservations")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationUseCase _useCase;

        public ReservationsController(IReservationUseCase useCase)
        {
            _useCase = useCase;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] DemandeReservationDto dto)
        {
            try
            {
                var idVoyage = new IdVoyage(dto.IdVoyage);
                var passagers =
                    dto.Passagers
                        .Select(p => p.ToDomain())
                        .ToList();

                await _useCase.ReserverAsync(idVoyage, passagers);
                return Ok();
            }
            catch (EmailInvalideException)
            {
                return BadRequest("Email invalide");
            }
            catch (VoyageSansTrainException)
            {
                return NotFound("Pas de train pour ce voyage");
            }
            catch (TrainPleinException)
            {
                return BadRequest("Train plein");
            }
            catch (VoiturePleineException)
            {
                return BadRequest("Voiture pleine");
            }
            catch (Exception)
            {
                return Problem();
            }
        }
    }
}