﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaCompra.Infra.Data;

namespace SistemaCompra.API.Migrations
{
    [DbContext(typeof(SistemaCompraContext))]
    [Migration("20221106184701_ApplingEspecificConfiguration")]
    partial class ApplingEspecificConfiguration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SistemaCompra.Domain.ProdutoAggregate.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Categoria")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("SistemaCompra.Domain.SolicitacaoCompraAggregate.ItemDaCompra", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Qtde")
                        .HasColumnType("int");

                    b.Property<Guid>("SolicitacaoDeCompraId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("SolicitacaoDeCompraId");

                    b.ToTable("ItemDaCompra");
                });

            modelBuilder.Entity("SistemaCompra.Domain.SolicitacaoCompraAggregate.SolicitacaoDeCompra", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDaCompra")
                        .HasColumnType("datetime2");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalDaCompra")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("SolicitacoesDeCompra");
                });

            modelBuilder.Entity("SistemaCompra.Domain.SolicitacaoCompraAggregate.ItemDaCompra", b =>
                {
                    b.HasOne("SistemaCompra.Domain.ProdutoAggregate.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");

                    b.HasOne("SistemaCompra.Domain.SolicitacaoCompraAggregate.SolicitacaoDeCompra", "SolicitacaoDeCompra")
                        .WithMany("ItensDaCompra")
                        .HasForeignKey("SolicitacaoDeCompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaCompra.Domain.SolicitacaoCompraAggregate.SolicitacaoDeCompra", b =>
                {
                    b.OwnsOne("SistemaCompra.Domain.SolicitacaoCompraAggregate.CondicaoDePagamento", "CondicaoDePgamento", b1 =>
                        {
                            b1.Property<Guid>("SolicitacaoDeCompraId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("CondicaoEmDias")
                                .HasColumnName("CondicaoDePagamentoEmDias")
                                .HasColumnType("int");

                            b1.HasKey("SolicitacaoDeCompraId");

                            b1.ToTable("SolicitacoesDeCompra");

                            b1.WithOwner()
                                .HasForeignKey("SolicitacaoDeCompraId");
                        });

                    b.OwnsOne("SistemaCompra.Domain.SolicitacaoCompraAggregate.Fornecedor", "NomeFornecedor", b1 =>
                        {
                            b1.Property<Guid>("SolicitacaoDeCompraId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Nome")
                                .HasColumnName("NomeDoFornecedor")
                                .HasColumnType("VARCHAR(100)");

                            b1.HasKey("SolicitacaoDeCompraId");

                            b1.ToTable("SolicitacoesDeCompra");

                            b1.WithOwner()
                                .HasForeignKey("SolicitacaoDeCompraId");
                        });

                    b.OwnsOne("SistemaCompra.Domain.SolicitacaoCompraAggregate.UsuarioSolicitante", "UsuarioSolicitante", b1 =>
                        {
                            b1.Property<Guid>("SolicitacaoDeCompraId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Nome")
                                .HasColumnName("NomeUsuarioSolicitante")
                                .HasColumnType("VARCHAR(100)");

                            b1.HasKey("SolicitacaoDeCompraId");

                            b1.ToTable("SolicitacoesDeCompra");

                            b1.WithOwner()
                                .HasForeignKey("SolicitacaoDeCompraId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
