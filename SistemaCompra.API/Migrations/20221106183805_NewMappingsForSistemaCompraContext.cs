using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class NewMappingsForSistemaCompraContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolicitacaoCompra",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "CondicaoPagamento",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "NomeFornecedor",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "Situacao",
                table: "SolicitacaoCompra");

            migrationBuilder.DropColumn(
                name: "TotalGeral",
                table: "SolicitacaoCompra");

            migrationBuilder.RenameTable(
                name: "SolicitacaoCompra",
                newName: "UsuarioSolicitante");

            migrationBuilder.RenameColumn(
                name: "UsuarioSolicitante",
                table: "UsuarioSolicitante",
                newName: "Nome");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Produto",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioSolicitante",
                table: "UsuarioSolicitante",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CondicaoDePagamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CondicaoEmDias = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondicaoDePagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SolicitacoesDeCompra",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDaCompra = table.Column<DateTime>(nullable: false),
                    TotalDaCompra = table.Column<decimal>(nullable: false),
                    Situacao = table.Column<int>(nullable: false),
                    UsuarioSolicitanteId = table.Column<Guid>(nullable: true),
                    NomeFornecedor_Id = table.Column<Guid>(nullable: true),
                    NomeDoFornecedor = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    CondicaoDePgamentoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitacoesDeCompra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitacoesDeCompra_CondicaoDePagamento_CondicaoDePgamentoId",
                        column: x => x.CondicaoDePgamentoId,
                        principalTable: "CondicaoDePagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SolicitacoesDeCompra_UsuarioSolicitante_UsuarioSolicitanteId",
                        column: x => x.UsuarioSolicitanteId,
                        principalTable: "UsuarioSolicitante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemDaCompra",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: true),
                    Qtde = table.Column<int>(nullable: false),
                    SolicitacaoDeCompraId = table.Column<Guid>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacoesDeCompra_CondicaoDePgamentoId",
                table: "SolicitacoesDeCompra",
                column: "CondicaoDePgamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacoesDeCompra_UsuarioSolicitanteId",
                table: "SolicitacoesDeCompra",
                column: "UsuarioSolicitanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemDaCompra");

            migrationBuilder.DropTable(
                name: "SolicitacoesDeCompra");

            migrationBuilder.DropTable(
                name: "CondicaoDePagamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioSolicitante",
                table: "UsuarioSolicitante");

            migrationBuilder.RenameTable(
                name: "UsuarioSolicitante",
                newName: "SolicitacaoCompra");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "SolicitacaoCompra",
                newName: "UsuarioSolicitante");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Produto",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<int>(
                name: "CondicaoPagamento",
                table: "SolicitacaoCompra",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeFornecedor",
                table: "SolicitacaoCompra",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "SolicitacaoCompra",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Situacao",
                table: "SolicitacaoCompra",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalGeral",
                table: "SolicitacaoCompra",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolicitacaoCompra",
                table: "SolicitacaoCompra",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Qtde = table.Column<int>(type: "int", nullable: false),
                    SolicitacaoCompraId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_SolicitacaoCompra_SolicitacaoCompraId",
                        column: x => x.SolicitacaoCompraId,
                        principalTable: "SolicitacaoCompra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_ProdutoId",
                table: "Item",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_SolicitacaoCompraId",
                table: "Item",
                column: "SolicitacaoCompraId");
        }
    }
}
