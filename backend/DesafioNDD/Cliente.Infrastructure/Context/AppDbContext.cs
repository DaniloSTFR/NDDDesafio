
using Cliente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Cliente.Infrastructure.EntityConfiguration;

namespace Cliente.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Clientes> Clientes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClientesConfiguration());
        }
    }
}