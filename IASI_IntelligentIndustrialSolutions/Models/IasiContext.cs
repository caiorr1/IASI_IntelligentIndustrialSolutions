using Microsoft.EntityFrameworkCore;

namespace IASI_IntelligentIndustrialSolutions.Models
{
    public class IasiContext : DbContext
    {
        public IasiContext(DbContextOptions<IasiContext> options) : base(options)
        {
        }
        public DbSet<Consumo> Consumo { get; set; }
        public DbSet<Equipamento> Equipamento { get; set; }
        public DbSet<Empresa> Empresa { get; set; }

    }
}
