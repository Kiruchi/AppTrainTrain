using System;
using System.Threading.Tasks;
using Flotte.Web.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flotte.Web.Locomotives
{
    [ApiController]
    [Route("flotte/locomotives")]
    public class LocomotiveController : ControllerBase
    {
        private readonly FlotteContext _context;

        public LocomotiveController(FlotteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var locomotives = await _context.Set<Locomotive>().ToListAsync();
            return Ok(locomotives);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var locomotive = await _context.Set<Locomotive>().FindAsync(id);
            return
                locomotive != null 
                    ? Ok(locomotive)
                    : (IActionResult) NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Locomotive locomotive)
        {
            var newLocomotive = new Locomotive
            {
                Marque = locomotive.Marque,
                Modele = locomotive.Modele,
                TractionMax = locomotive.TractionMax
            };

            await _context.AddAsync(newLocomotive);
            await _context.SaveChangesAsync();

            return Ok(newLocomotive);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var locomotive = await _context.Set<Locomotive>().FindAsync(id);
            if (locomotive != null)
                _context.Set<Locomotive>().Remove(locomotive);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}