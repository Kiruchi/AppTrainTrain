using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Reservations.Web.Controllers
{
    [ApiController]
    [Route("reservations")]
    public class ReservationsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostAsync()
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}