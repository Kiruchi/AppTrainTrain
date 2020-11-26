using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reseau.Web.Db;

namespace Reseau.Web.Lignes
{
    [ApiController]
    [Route("reseau/lignes")]
    public class LignesController : ControllerBase
    {
        private readonly ReseauContext _context;

        public LignesController(ReseauContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var lignes = await _context.Set<Ligne>().ToListAsync();
            return Ok(lignes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var ligne = await _context.Set<Ligne>().FindAsync(id);
            return
                ligne != null 
                    ? Ok(ligne)
                    : (IActionResult) NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Ligne ligne)
        {
            var newLigne = new Ligne
            {
                GareDepartId = ligne.GareDepartId,
                GareArriveeId = ligne.GareArriveeId,
                DureeTrajet = ligne.DureeTrajet
            };

            await _context.AddAsync(newLigne);
            await _context.SaveChangesAsync();

            return Ok(newLigne);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var ligne = await _context.Set<Ligne>().FindAsync(id);
            if (ligne != null)
                _context.Set<Ligne>().Remove(ligne);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}