using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IASI_IntelligentIndustrialSolutions.Models;

public class EquipamentoController : Controller
{
    private readonly IEquipamentoRepository _equipamentoRepository;

    public EquipamentoController(IEquipamentoRepository equipamentoRepository)
    {
        _equipamentoRepository = equipamentoRepository;
    }

    // GET: Equipamento
    public async Task<IActionResult> Index()
    {
        var equipamentos = await _equipamentoRepository.GetAllAsync();
        return View(equipamentos);
    }

    // GET: Equipamento/Details/{id}
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var equipamento = await _equipamentoRepository.GetByIdAsync(id.Value);
        if (equipamento == null) return NotFound();

        return View(equipamento);
    }

    // GET: Equipamento/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Equipamento/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("IdEquipamento,Nome,Tipo,Localizacao,DataInstalacao,Estado")] Equipamento equipamento)
    {
        if (ModelState.IsValid)
        {
            await _equipamentoRepository.AddAsync(equipamento);
            return RedirectToAction(nameof(Index));
        }
        return View(equipamento);
    }

    // GET: Equipamento/Edit/{id}
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var equipamento = await _equipamentoRepository.GetByIdAsync(id.Value);
        if (equipamento == null) return NotFound();

        return View(equipamento);
    }

    // POST: Equipamento/Edit/{id}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("IdEquipamento,Nome,Descricao")] Equipamento equipamento)
    {
        if (id != equipamento.IdEquipamento) return NotFound();

        if (ModelState.IsValid)
        {
            await _equipamentoRepository.UpdateAsync(equipamento);
            return RedirectToAction(nameof(Index));
        }
        return View(equipamento);
    }

}



