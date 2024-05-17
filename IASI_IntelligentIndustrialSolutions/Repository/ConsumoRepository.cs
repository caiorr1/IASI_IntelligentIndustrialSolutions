using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IASI_IntelligentIndustrialSolutions.Models;

public class ConsumoRepository : IConsumoRepository
{
    private readonly IasiContext _context;

    public ConsumoRepository(IasiContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Consumo>> GetAllAsync()
    {
        return await _context.Consumo.ToListAsync();
    }

    public async Task<Consumo> GetByIdAsync(int id)
    {
        return await _context.Consumo.FindAsync(id);
    }

    public async Task AddAsync(Consumo consumo)
    {
        await _context.Consumo.AddAsync(consumo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Consumo consumo)
    {
        _context.Consumo.Update(consumo);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var consumo = await _context.Consumo.FindAsync(id);
        if (consumo != null)
        {
            _context.Consumo.Remove(consumo);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Consumo.AnyAsync(e => e.IdConsumo == id);
    }
}
