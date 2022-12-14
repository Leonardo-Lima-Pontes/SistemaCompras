using SistemaCompra.Domain.Core;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class UsuarioSolicitante
    {
        public string Nome { get; private set; }

        private UsuarioSolicitante() { }

        public UsuarioSolicitante(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new BusinessRuleException("Nome do usuário solicitante não pode ser nulo."); 
            if (nome.Length < 3) throw new BusinessRuleException("Nome de usuário deve possuir pelo menos 3 caracteres.");
            
            Nome = nome;
        }
    }
}
