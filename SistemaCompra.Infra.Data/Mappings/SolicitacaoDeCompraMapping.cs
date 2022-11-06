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

            builder.HasMany(s => s.ItensDaCompra)
                .WithOne(s => s.SolicitacaoDeCompra)
                .HasForeignKey(s => s.SolicitacaoDeCompraId);

            builder.HasOne(s => s.NomeFornecedor);
            builder.HasOne(s => s.CondicaoDePgamento);
            builder.HasOne(s => s.UsuarioSolicitante);
        }
    }
}