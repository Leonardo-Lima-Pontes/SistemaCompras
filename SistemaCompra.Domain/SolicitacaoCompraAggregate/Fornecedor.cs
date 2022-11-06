using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class Fornecedor : Entity
    {
        public string Nome { get; private set; }

        private Fornecedor() { }

        public Fornecedor(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new BusinessRuleException("Nome de fornecedor não pode ser nulo.");
            if (nome.Length < 3) throw new BusinessRuleException("Nome de fornecedor deve ter pelo menos 3 caracteres.");

            Nome = nome;
        }
    }
}
