using System.Collections.Generic;
using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.SolicitacaoDeCompraStack.Commands
{
    public class RegistrarCompraCommand : IRequest<bool>
    {
        public string NomeDoFornecedor { get; set; }
        public string NomeDoUsuarioSolicitante { get; set; }
        public int CondicaoDePagamentoEmdias { get; set; }
        public IList<ItemDaCompra> Itens { get; set; }
    }
}
