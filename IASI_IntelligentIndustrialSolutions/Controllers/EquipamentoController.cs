using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IASI_IntelligentIndustrialSolutions.Models;
using Microsoft.AspNetCore.Authentication;

namespace IASI.Controllers
{
    public class EquipamentoController : Controller
    {
        private readonly IasiContext _context;

        public EquipamentoController(IasiContext context)
        {
            _context = context;
        }

        // GET: Equipamento
        public async Task<IActionResult> Index()
        {
            var equipamentos = await _context.Equipamento.ToListAsync();
            return View(equipamentos);
        }

        // GET: api/Equipamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipamento>>> GetEquipamentos()
        {
            return await _context.Equipamento.ToListAsync();
        }

        // GET: api/Equipamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipamento>> GetEquipamento(int id)
        {
            var equipamento = await _context.Equipamento.FindAsync(id);

            if (equipamento == null)
            {
                return NotFound();
            }

            return equipamento;
        }

        // POST: api/Equipamento
        [HttpPost]
        public async Task<ActionResult<Equipamento>> PostEquipamento(Equipamento equipamento)
        {
            _context.Equipamento.Add(equipamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEquipamento), new { id = equipamento.IdEquipamento }, equipamento);
        }

        // PUT: api/Equipamento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipamento(int id, Equipamento equipamento)
        {
            if (id != equipamento.IdEquipamento)
            {
                return BadRequest();
            }

            _context.Entry(equipamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipamentoExists(id))
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

        // DELETE: api/Equipamento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipamento(int id)
        {
            var equipamento = await _context.Equipamento.FindAsync(id);
            if (equipamento == null)
            {
                return NotFound();
            }

            _context.Equipamento.Remove(equipamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipamentoExists(int id)
        {
            return _context.Equipamento.Any(e => e.IdEquipamento == id);
        }
    }
}
