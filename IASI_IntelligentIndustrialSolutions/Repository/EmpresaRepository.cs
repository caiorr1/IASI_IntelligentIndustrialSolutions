using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IASI_IntelligentIndustrialSolutions.Models;

public class EmpresaRepository : IEmpresaRepository
{
    private readonly IasiContext _context;

    public EmpresaRepository(IasiContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Empresa>> GetAllAsync()
    {
        return await _context.Empresa.ToListAsync();
    }

    public async Task<Empresa> GetByIdAsync(int id)
    {
        return await _context.Empresa.FindAsync(id);
    }

    public async Task AddAsync(Empresa empresa)
    {
        await _context.Empresa.AddAsync(empresa);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Empresa empresa)
    {
        _context.Empresa.Update(empresa);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var empresa = await _context.Empresa.FindAsync(id);
        if (empresa != null)
        {
            _context.Empresa.Remove(empresa);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Empresa.AnyAsync(e => e.IdEmpresa == id);
    }
}
