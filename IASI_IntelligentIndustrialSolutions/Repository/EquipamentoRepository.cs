using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IASI_IntelligentIndustrialSolutions.Models;

public class EquipamentoRepository : IEquipamentoRepository
{
    private readonly IasiContext _context;

    public EquipamentoRepository(IasiContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Equipamento>> GetAllAsync()
    {
        return await _context.Equipamento.ToListAsync();
    }

    public async Task<Equipamento> GetByIdAsync(int id)
    {
        return await _context.Equipamento.FindAsync(id);
    }

    public async Task AddAsync(Equipamento equipamento)
    {
        await _context.Equipamento.AddAsync(equipamento);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Equipamento equipamento)
    {
        _context.Equipamento.Update(equipamento);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var equipamento = await _context.Equipamento.FindAsync(id);
        if (equipamento != null)
        {
            _context.Equipamento.Remove(equipamento);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Equipamento.AnyAsync(e => e.IdEquipamento == id);
    }
}
