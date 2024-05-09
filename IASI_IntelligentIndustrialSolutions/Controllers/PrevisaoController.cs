using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IASI_IntelligentIndustrialSolutions.Models;
using Microsoft.AspNetCore.Authentication;

namespace IASI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrevisaoController : ControllerBase
    {
        private readonly IasiContext _context;

        public PrevisaoController(IasiContext context)
        {
            _context = context;
        }

        // GET: api/Previsao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Previsao>>> GetPrevisoes()
        {
            return await _context.Previsao.ToListAsync();
        }

        // GET: api/Previsao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Previsao>> GetPrevisao(int id)
        {
            var previsao = await _context.Previsao.FindAsync(id);

            if (previsao == null)
            {
                return NotFound();
            }

            return previsao;
        }

        // GET: api/Previsao/Index
        [HttpGet("Index")]
        public async Task<ActionResult<IEnumerable<Previsao>>> Index()
        {
            return await _context.Previsao.ToListAsync();
        }

        // POST: api/Previsao
        [HttpPost]
        public async Task<ActionResult<Previsao>> PostPrevisao(Previsao previsao)
        {
            _context.Previsao.Add(previsao);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPrevisao), new { id = previsao.IdPrevisao }, previsao);
        }

        // PUT: api/Previsao/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrevisao(int id, Previsao previsao)
        {
            if (id != previsao.IdPrevisao)
            {
                return BadRequest();
            }

            _context.Entry(previsao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrevisaoExists(id))
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

        // DELETE: api/Previsao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrevisao(int id)
        {
            var previsao = await _context.Previsao.FindAsync(id);
            if (previsao == null)
            {
                return NotFound();
            }

            _context.Previsao.Remove(previsao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrevisaoExists(int id)
        {
            return _context.Previsao.Any(e => e.IdPrevisao == id);
        }
    }
}
