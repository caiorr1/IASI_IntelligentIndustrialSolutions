using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IASI_IntelligentIndustrialSolutions.Models;

namespace IASI_IntelligentIndustrialSolutions.Controllers
{
    public class PrevisaoController : Controller
    {
        private readonly IasiContext _context;

        public PrevisaoController(IasiContext context)
        {
            _context = context;
        }

        // GET: Previsao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Previsao.ToListAsync());
        }

        // GET: Previsao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var previsao = await _context.Previsao
                .FirstOrDefaultAsync(m => m.IdPrevisao == id);
            if (previsao == null)
            {
                return NotFound();
            }

            return View(previsao);
        }

        // GET: Previsao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Previsao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPrevisao,IdEquipamento,Data,TipoPrevisao,Descricao,Probabilidade")] Previsao previsao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(previsao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(previsao);
        }

        // GET: Previsao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var previsao = await _context.Previsao.FindAsync(id);
            if (previsao == null)
            {
                return NotFound();
            }
            return View(previsao);
        }

        // POST: Previsao/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPrevisao,IdEquipamento,Data,TipoPrevisao,Descricao,Probabilidade")] Previsao previsao)
        {
            if (id != previsao.IdPrevisao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(previsao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrevisaoExists(previsao.IdPrevisao))
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
            return View(previsao);
        }

        // GET: Previsao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var previsao = await _context.Previsao
                .FirstOrDefaultAsync(m => m.IdPrevisao == id);
            if (previsao == null)
            {
                return NotFound();
            }

            return View(previsao);
        }

        // POST: Previsao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var previsao = await _context.Previsao.FindAsync(id);
            if (previsao != null)
            {
                _context.Previsao.Remove(previsao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrevisaoExists(int id)
        {
            return _context.Previsao.Any(e => e.IdPrevisao == id);
        }
    }
}
