using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.Core;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class ItemDaCompra : Entity
    {
        public Produto Produto { get; private set; }
        public int Qtde { get; private set; }
        public int SolicitacaoDeCompraId { get; private set; }
        public SolicitacaoDeCompra SolicitacaoDeCompra { get; set; }
        private ItemDaCompra() { }

        public ItemDaCompra(Produto produto, int qtde)
        {
            if (produto == null) throw new BusinessRuleException("O item da compra não pode ser nulo");
            if (qtde < 1) throw new BusinessRuleException("Quantidade de itens da campo deve ser maior que 0");
            
            Produto = produto;
            Qtde = qtde;
        }

        public decimal ObterSubTotal() => Produto.Preco * Qtde;
    }
}
