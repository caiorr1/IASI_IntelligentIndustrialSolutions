using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IASI_IntelligentIndustrialSolutions.Models;

public class EmpresaController : Controller
{
    private readonly IEmpresaRepository _empresaRepository;

    public EmpresaController(IEmpresaRepository empresaRepository)
    {
        _empresaRepository = empresaRepository;
    }

    // GET: Empresa
    public async Task<IActionResult> Index()
    {
        var empresas = await _empresaRepository.GetAllAsync();
        return View(empresas);
    }

    // GET: Empresa/Details/{id}
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var empresa = await _empresaRepository.GetByIdAsync(id.Value);
        if (empresa == null) return NotFound();

        return View(empresa);
    }

    // GET: Empresa/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Empresa/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("IdEmpresa,Nome,CNPJ")] Empresa empresa)
    {
        if (ModelState.IsValid)
        {
            await _empresaRepository.AddAsync(empresa);
            return RedirectToAction(nameof(Index));
        }
        return View(empresa);
    }

    // GET: Empresa/Edit/{id}
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var empresa = await _empresaRepository.GetByIdAsync(id.Value);
        if (empresa == null) return NotFound();

        return View(empresa);
    }

    // POST: Empresa/Edit/{id}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("IdEmpresa,Nome,CNPJ")] Empresa empresa)
    {
        if (id != empresa.IdEmpresa) return NotFound();

        if (ModelState.IsValid)
        {
            await _empresaRepository.UpdateAsync(empresa);
            return RedirectToAction(nameof(Index));
        }
        return View(empresa);
    }

    // GET: Empresa/Delete/{id}
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var empresa = await _empresaRepository.GetByIdAsync(id.Value);
        if (empresa == null) return NotFound();

        return View(empresa);
    }

    // POST: Empresa/Delete/{id}
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _empresaRepository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
