using BoletoService.Domain.Entities;
using BoletoService.Infra.EntityMap;
using Microsoft.EntityFrameworkCore;

namespace BoletoService.Infra.Context
{
    public class BoletoContext : DbContext
    {
        public BoletoContext(DbContextOptions<BoletoContext> options) : base(options)
        {

        }
        public DbSet<Boleto> Boletos { get; set; }
        public DbSet<Banco> Bancos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BoletoMap());
            modelBuilder.ApplyConfiguration(new BancoMap());
        }
    }
}
