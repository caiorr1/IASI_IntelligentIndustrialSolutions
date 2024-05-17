using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using IASI_IntelligentIndustrialSolutions.Models;

public class ConsumoController : Controller
{
    private readonly IConsumoRepository _consumoRepository;
    private readonly IasiContext _context;

    public ConsumoController(IConsumoRepository consumoRepository, IasiContext context)
    {
        _consumoRepository = consumoRepository;
        _context = context;
    }

    // GET: Consumo
    public async Task<IActionResult> Index()
    {
        var consumos = await _consumoRepository.GetAllAsync();
        return View(consumos);
    }

    // GET: Consumo/Details/{id}
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var consumo = await _consumoRepository.GetByIdAsync(id.Value);
        if (consumo == null) return NotFound();

        return View(consumo);
    }

    // GET: Consumo/Create
    public IActionResult Create()
    {
        ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "IdEquipamento", "IdEquipamento");
        return View();
    }

    // POST: Consumo/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("IdConsumo,EquipamentoId,Data,Quantidade,UnidadeMedida,EmissaoGas,Descricao")] Consumo consumo)
    {
        if (ModelState.IsValid)
        {
            await _consumoRepository.AddAsync(consumo);
            return RedirectToAction(nameof(Index));
        }
        ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "IdEquipamento", "IdEquipamento", consumo.EquipamentoId);
        return View(consumo);
    }

    // GET: Consumo/Edit/{id}
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var consumo = await _consumoRepository.GetByIdAsync(id.Value);
        if (consumo == null) return NotFound();

        ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "IdEquipamento", "IdEquipamento", consumo.EquipamentoId);
        return View(consumo);
    }

    // POST: Consumo/Edit/{id}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("IdConsumo,EquipamentoId,Data,Quantidade,UnidadeMedida,EmissaoGas,Descricao")] Consumo consumo)
    {
        if (id != consumo.IdConsumo) return NotFound();

        if (ModelState.IsValid)
        {
            await _consumoRepository.UpdateAsync(consumo);
            return RedirectToAction(nameof(Index));
        }
        ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "IdEquipamento", "IdEquipamento", consumo.EquipamentoId);
        return View(consumo);
    }

    // GET: Consumo/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var consumo = await _consumoRepository.GetByIdAsync(id.Value);
        if (consumo == null) return NotFound();

        return View(consumo);
    }

    // POST: Consumo/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _consumoRepository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
