using System;
using System.Threading.Tasks;
using Flotte.Web.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flotte.Web.Wagons
{
    [ApiController]
    [Route("flotte/wagons")]
    public class WagonsController : ControllerBase
    {
        private readonly FlotteContext _context;

        public WagonsController(FlotteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var wagons = await _context.Set<Wagon>().ToListAsync();
            return Ok(wagons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var wagon = await _context.Set<Wagon>().FindAsync(id);
            return
                wagon != null 
                    ? Ok(wagon)
                    : (IActionResult) NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Wagon wagon)
        {
            var newWagon = new Wagon
            {
                Marque = wagon.Marque,
                Modele = wagon.Modele,
                Poids = wagon.Poids
            };

            await _context.AddAsync(newWagon);
            await _context.SaveChangesAsync();

            return Ok(newWagon);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var wagon = await _context.Set<Wagon>().FindAsync(id);
            if (wagon != null)
                _context.Set<Wagon>().Remove(wagon);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}