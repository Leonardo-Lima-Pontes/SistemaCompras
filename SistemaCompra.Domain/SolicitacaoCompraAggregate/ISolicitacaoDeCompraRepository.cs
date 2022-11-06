namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public interface ISolicitacaoDeCompraRepository
    {
        void RegistrarCompra(SolicitacaoDeCompra solicitacaoCompra);
    }
}
