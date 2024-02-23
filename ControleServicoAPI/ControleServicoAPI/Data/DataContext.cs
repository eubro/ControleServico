using ControleServicoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleServicoAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<CadServico> CadServicos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
        }


    }
}
