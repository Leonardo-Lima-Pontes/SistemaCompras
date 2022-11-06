using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class RetirandoTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemDaCompra");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemDaCompra",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Qtde = table.Column<int>(type: "int", nullable: false),
                    SolicitacaoDeCompraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDaCompra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemDaCompra_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemDaCompra_SolicitacoesDeCompra_SolicitacaoDeCompraId",
                        column: x => x.SolicitacaoDeCompraId,
                        principalTable: "SolicitacoesDeCompra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemDaCompra_ProdutoId",
                table: "ItemDaCompra",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDaCompra_SolicitacaoDeCompraId",
                table: "ItemDaCompra",
                column: "SolicitacaoDeCompraId");
        }
    }
}
