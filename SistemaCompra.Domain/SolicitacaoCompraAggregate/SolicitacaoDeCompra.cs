﻿using SistemaCompra.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using SistemaCompra.Domain.Core;

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
        public IList<ItemDaCompra> ItensDaCompra { get; private set; }

        private SolicitacaoDeCompra() { }

        public SolicitacaoDeCompra(string usuarioSolicitante, string nomeFornecedor, int condicaoDePagamentoEmDias)
        {
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new Fornecedor(nomeFornecedor);
            CondicaoDePgamento = new CondicaoDePagamento(condicaoDePagamentoEmDias);
            DataDaCompra = DateTime.Now;
            Situacao = Situacao.Solicitado;
            ItensDaCompra = new List<ItemDaCompra>();
        }

        public void RegistrarCompra(IEnumerable<ItemDaCompra> itensDaCompra)
        {
            AtribuirItensDaCompra(itensDaCompra.ToList());
            ProcessarTotalDaCompra();
            ProcesarCondicaoDePagamento();
        }

        private void ProcesarCondicaoDePagamento()
        {
            if (TotalDaCompra > 50000m)
                CondicaoDePgamento.ModificarCondicaoDePagamentoPara30Dias();
        }

        private void ProcessarTotalDaCompra() => TotalDaCompra = ItensDaCompra.Sum(item => item.ObterSubTotal());

        private void AtribuirItensDaCompra(IReadOnlyCollection<ItemDaCompra> itemsDaCompra)
        {
            if (!itemsDaCompra.Any()) throw new BusinessRuleException("O compra precisa conter itens para ser registrada");

            ItensDaCompra.ToList().AddRange(itemsDaCompra);
        }
    }
}
