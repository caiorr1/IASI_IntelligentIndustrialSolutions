using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IASI_IntelligentIndustrialSolutions.Models;

namespace IASI_IntelligentIndustrialSolutions.Controllers
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
            var consumos = await _context.Consumo.Include(c => c.Equipamento).ToListAsync();
            return View(consumos);
        }

        // GET: Consumo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumo = await _context.Consumo
                .Include(c => c.Equipamento)
                .FirstOrDefaultAsync(m => m.IdConsumo == id);
            if (consumo == null)
            {
                return NotFound();
            }

            return View(consumo);
        }

        // GET: Consumo/Create
        public IActionResult Create()
        {
            ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "IdEquipamento", "Localizacao");
            return View();
        }

        // POST: Consumo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConsumo,Data,EquipamentoId,Quantidade,UnidadeMedida,Descricao,EmissaoGas")] Consumo consumo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consumo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "IdEquipamento", "Localizacao", consumo.EquipamentoId);
            return View(consumo);
        }

        // GET: Consumo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumo = await _context.Consumo.FindAsync(id);
            if (consumo == null)
            {
                return NotFound();
            }
            ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "IdEquipamento", "Localizacao", consumo.EquipamentoId);
            return View(consumo);
        }

        // POST: Consumo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConsumo,Data,EquipamentoId,Quantidade,UnidadeMedida,Descricao,EmissaoGas")] Consumo consumo)
        {
            if (id != consumo.IdConsumo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consumo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumoExists(consumo.IdConsumo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "IdEquipamento", "Localizacao", consumo.EquipamentoId);
            return View(consumo);
        }

        // GET: Consumo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumo = await _context.Consumo
                .Include(c => c.Equipamento)
                .FirstOrDefaultAsync(m => m.IdConsumo == id);
            if (consumo == null)
            {
                return NotFound();
            }

            return View(consumo);
        }

        // POST: Consumo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consumo = await _context.Consumo.FindAsync(id);
            if (consumo != null)
            {
                _context.Consumo.Remove(consumo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsumoExists(int id)
        {
            return _context.Consumo.Any(e => e.IdConsumo == id);
        }
    }
}
