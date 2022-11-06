using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.Mappings
{
    public class SolicitacaoDeCompraMapping : IEntityTypeConfiguration<SolicitacaoDeCompra>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoDeCompra> builder)
        {
            builder.HasKey(s => s.Id);

            builder.OwnsOne(c => c.NomeFornecedor, cm =>
            {
                cm.Property(c => c.Nome)
                    .HasColumnName("NomeDoFornecedor")
                    .HasColumnType("VARCHAR(100)");
            });
            
            builder.OwnsOne(c => c.CondicaoDePgamento, cm =>
            {
                cm.Property(c => c.CondicaoEmDias)
                    .HasColumnName("CondicaoDePagamentoEmDias")
                    .HasColumnType("int");
            });
            
            builder.OwnsOne(c => c.UsuarioSolicitante, cm =>
            {
                cm.Property(c => c.Nome)
                    .HasColumnName("NomeUsuarioSolicitante")
                    .HasColumnType("VARCHAR(100)");
            });
            
            builder.ToTable("SolicitacoesDeCompra");
        }
    }
}