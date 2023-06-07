using DevPratica.Locacao.Modelo;
using Microsoft.EntityFrameworkCore;

namespace DevPratica.Locacao.Infra.Entity
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; } = null;
        public DbSet<Fornecedor> Fornecedores { get; set; } = null;
        public DbSet<Equipamento> Equipamentos { get; set; } = null;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Equipamento>().Property(p => p.Valor).HasPrecision(18, 2);
        }

    }
}
