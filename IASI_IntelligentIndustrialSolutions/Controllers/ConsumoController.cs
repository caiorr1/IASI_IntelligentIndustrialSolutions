using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IASI_IntelligentIndustrialSolutions.Models;
using Microsoft.AspNetCore.Authentication;

namespace IASI.Controllers
{
    public class ConsumoController : Controller
    {
        private readonly IasiContext _context;

        public ConsumoController(IasiContext context)
        {
            _context = context;
        }

        // GET: Consumo
        public async Task<IActionResult> Index()
        {
            var consumos = await _context.Consumo.ToListAsync();
            return View(consumos);
        }

        // GET: api/Consumo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consumo>>> GetConsumos()
        {
            return await _context.Consumo.ToListAsync();
        }

        // GET: api/Consumo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Consumo>> GetConsumo(int id)
        {
            var consumo = await _context.Consumo.FindAsync(id);

            if (consumo == null)
            {
                return NotFound();
            }

            return consumo;
        }

        // POST: api/Consumo
        [HttpPost]
        public async Task<ActionResult<Consumo>> PostConsumo(Consumo consumo)
        {
            _context.Consumo.Add(consumo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetConsumo), new { id = consumo.IdConsumo }, consumo);
        }

        // PUT: api/Consumo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsumo(int id, Consumo consumo)
        {
            if (id != consumo.IdConsumo)
            {
                return BadRequest();
            }

            _context.Entry(consumo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsumoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Consumo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsumo(int id)
        {
            var consumo = await _context.Consumo.FindAsync(id);
            if (consumo == null)
            {
                return NotFound();
            }

            _context.Consumo.Remove(consumo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsumoExists(int id)
        {
            return _context.Consumo.Any(e => e.IdConsumo == id);
        }
    }
}
