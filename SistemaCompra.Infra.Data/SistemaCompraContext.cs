using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data
{
    public class SistemaCompraContext : DbContext
    {
        private static readonly ILoggerFactory LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder => { builder.AddConsole(); });

        public SistemaCompraContext(DbContextOptions<SistemaCompraContext> options) : base(options) { }
        
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<SolicitacaoDeCompra> SolicitacoesDeCompra { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SistemaCompraContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory)  
                .EnableSensitiveDataLogging()
                .UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=MinhaApiCore;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
