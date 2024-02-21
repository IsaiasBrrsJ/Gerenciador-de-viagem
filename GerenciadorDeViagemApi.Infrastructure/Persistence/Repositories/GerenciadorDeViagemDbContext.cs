using GerenciadorDeViagem.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GerenciadorDeViagemApi.Infrastructure.Persistence.Repositories
{
    public class GerenciadorDeViagemDbContext : DbContext
    {
        public GerenciadorDeViagemDbContext(DbContextOptions<GerenciadorDeViagemDbContext> options) : base(options)
        { }
        public DbSet<Usuario> Usuario { get; set; }    
        public DbSet<Viagem> Viagens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
       
    }
}
