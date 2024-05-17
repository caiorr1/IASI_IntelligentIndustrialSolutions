using System.Collections.Generic;
using System.Threading.Tasks;
using IASI_IntelligentIndustrialSolutions.Models;

public interface IEquipamentoRepository
{
    Task<IEnumerable<Equipamento>> GetAllAsync();
    Task<Equipamento> GetByIdAsync(int id);
    Task AddAsync(Equipamento equipamento);
    Task UpdateAsync(Equipamento equipamento);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
