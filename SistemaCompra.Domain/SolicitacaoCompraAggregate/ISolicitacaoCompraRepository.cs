namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public interface ISolicitacaoCompraRepository
    {
        void RegistrarCompra(SolicitacaoDeCompra solicitacaoCompra);
    }
}
