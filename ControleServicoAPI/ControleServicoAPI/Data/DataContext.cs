using ControleServicoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleServicoAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<CadServico> CadServicos { get; set; }

        
    }
}
