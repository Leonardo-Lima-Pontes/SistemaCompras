using SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.Repositories
{
    public class SolicitacaoDeCompraRepository : ISolicitacaoDeCompraRepository
    {
        private readonly SistemaCompraContext _sistemaCompraContext;

        public SolicitacaoDeCompraRepository(SistemaCompraContext sistemaCompraContext)
        {
            _sistemaCompraContext = sistemaCompraContext;
        }

        public void RegistrarCompra(SolicitacaoDeCompra solicitacaoCompra) => 
            _sistemaCompraContext.SolicitacoesDeCompra.Add(solicitacaoCompra);
    }
}