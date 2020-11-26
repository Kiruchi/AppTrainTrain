using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reseau.Web.Db;

namespace Reseau.Web.Gares
{
    [ApiController]
    [Route("reseau/gares")]
    public class GaresController : ControllerBase
    {
        private readonly ReseauContext _context;

        public GaresController(ReseauContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var gares = await _context.Set<Gare>().ToListAsync();
            return Ok(gares);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var gare = await _context.Set<Gare>().FindAsync(id);
            return
                gare != null 
                    ? Ok(gare)
                    : (IActionResult) NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Gare gare)
        {
            var newLocomotive = new Gare
            {
                Nom = gare.Nom,
                NumeroRue = gare.NumeroRue,
                Rue = gare.Rue,
                CodePostal = gare.CodePostal,
                Ville = gare.Ville,
            };

            await _context.AddAsync(newLocomotive);
            await _context.SaveChangesAsync();

            return Ok(newLocomotive);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var gare = await _context.Set<Gare>().FindAsync(id);
            if (gare != null)
                _context.Set<Gare>().Remove(gare);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}