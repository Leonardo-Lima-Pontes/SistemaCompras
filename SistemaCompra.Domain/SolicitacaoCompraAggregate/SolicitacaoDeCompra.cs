using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using System;
using System.Collections.Generic;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoDeCompra : Entity
    {
        public DateTime DataDaCompra { get; private set; }
        public decimal TotalDaCompra { get; private set; }
        public Situacao Situacao { get; private set; }
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }
        public Fornecedor NomeFornecedor { get; private set; }
        public CondicaoDePagamento CondicaoDePgamento { get; private set; }
        public IList<ItemDaCompra> Itens { get; private set; }

        private SolicitacaoDeCompra() { }

        public SolicitacaoDeCompra(string usuarioSolicitante, string nomeFornecedor, int condicaoDePagamentoEmDias)
        {
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new Fornecedor(nomeFornecedor);
            CondicaoDePgamento = new CondicaoDePagamento(condicaoDePagamentoEmDias);
            DataDaCompra = DateTime.Now;
            Situacao = Situacao.Solicitado;
        }

        public void AdicionarItem(Produto produto, int qtde) => Itens.Add(new ItemDaCompra(produto, qtde));

        public void RegistrarCompra(IEnumerable<ItemDaCompra> itens)
        {
           
        }
    }
}
