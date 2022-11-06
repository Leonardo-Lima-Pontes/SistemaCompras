using SistemaCompra.Domain.Core;
using System.Collections.Generic;
using System.Linq;
using SistemaCompra.Domain.Core.Model;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class CondicaoDePagamento : Entity
    {
        private readonly IReadOnlyCollection<int> _valoresPossiveis = new List<int> { 0, 30, 60, 90 };
        public int CondicaoEmDias { get; private set; }

        private CondicaoDePagamento(){}

        public CondicaoDePagamento(int condicaoEmDias)
        {
            if (!_valoresPossiveis.Contains(condicaoEmDias)) throw new BusinessRuleException("Condição de pagamento deve ser " +_valoresPossiveis);

            CondicaoEmDias = condicaoEmDias;
        }
    }
}