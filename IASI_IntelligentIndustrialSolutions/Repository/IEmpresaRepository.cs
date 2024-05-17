using System.Collections.Generic;
using System.Threading.Tasks;
using IASI_IntelligentIndustrialSolutions.Models;

public interface IEmpresaRepository
{
    Task<IEnumerable<Empresa>> GetAllAsync();
    Task<Empresa> GetByIdAsync(int id);
    Task AddAsync(Empresa empresa);
    Task UpdateAsync(Empresa empresa);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
