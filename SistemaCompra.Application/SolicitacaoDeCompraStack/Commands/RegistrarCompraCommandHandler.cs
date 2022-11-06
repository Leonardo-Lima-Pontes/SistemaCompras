using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Infra.Data.UoW;

namespace SistemaCompra.Application.SolicitacaoDeCompraStack.Commands
{
    public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly ISolicitacaoDeCompraRepository _solicitacaoCompraRepository;
        
        public RegistrarCompraCommandHandler(
            ISolicitacaoDeCompraRepository solicitacaoCompraRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            _solicitacaoCompraRepository = solicitacaoCompraRepository;
        }

        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            var solicitacaoDeCompra = new SolicitacaoDeCompra(request.NomeDoUsuarioSolicitante, request.NomeDoFornecedor, request.CondicaoDePagamentoEmdias);
            solicitacaoDeCompra.RegistrarCompra(request.Itens);
            _solicitacaoCompraRepository.RegistrarCompra(solicitacaoDeCompra);

            Commit();
            PublishEvents(solicitacaoDeCompra.Events);

            return Task.FromResult(true);
        }
    }
}