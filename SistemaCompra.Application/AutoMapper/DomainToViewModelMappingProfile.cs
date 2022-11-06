﻿using AutoMapper;
using SistemaCompra.Application.Produto.Query.ObterProduto;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;

namespace SistemaCompra.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProdutoAgg.Produto, ObterProdutoViewModel>();
        }
    }
}
