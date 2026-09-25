using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Veiculo.Domain.Entities;
using Veiculo.Infrastructure.Identity;

namespace Veiculo.Infrastructure.Context
{
    public class CarroDbContext : IdentityDbContext<ApplicationUser>
    {
        public CarroDbContext(DbContextOptions<CarroDbContext> options) : base (options)
        {

        }

        public DbSet<Carro> Carros => Set<Carro>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Carro>(entity =>
            {
                entity.Property(c => c.Placa).IsRequired().HasMaxLength(10);
                entity.Property(c => c.Modelo).HasMaxLength(50);
                entity.Property(c => c.Status).HasConversion<string>().HasMaxLength(20);
            });
        }
    }
}
