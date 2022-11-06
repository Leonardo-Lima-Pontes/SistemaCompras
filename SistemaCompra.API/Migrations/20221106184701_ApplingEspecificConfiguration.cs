using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class ApplingEspecificConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacoesDeCompra_CondicaoDePagamento_CondicaoDePgamentoId",
                table: "SolicitacoesDeCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacoesDeCompra_UsuarioSolicitante_UsuarioSolicitanteId",
                table: "SolicitacoesDeCompra");

            migrationBuilder.DropTable(
                name: "CondicaoDePagamento");

            migrationBuilder.DropTable(
                name: "UsuarioSolicitante");

            migrationBuilder.DropIndex(
                name: "IX_SolicitacoesDeCompra_CondicaoDePgamentoId",
                table: "SolicitacoesDeCompra");

            migrationBuilder.DropIndex(
                name: "IX_SolicitacoesDeCompra_UsuarioSolicitanteId",
                table: "SolicitacoesDeCompra");

            migrationBuilder.DropColumn(
                name: "NomeFornecedor_Id",
                table: "SolicitacoesDeCompra");

            migrationBuilder.DropColumn(
                name: "CondicaoDePgamentoId",
                table: "SolicitacoesDeCompra");

            migrationBuilder.DropColumn(
                name: "UsuarioSolicitanteId",
                table: "SolicitacoesDeCompra");

            migrationBuilder.AddColumn<int>(
                name: "CondicaoDePagamentoEmDias",
                table: "SolicitacoesDeCompra",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeUsuarioSolicitante",
                table: "SolicitacoesDeCompra",
                type: "VARCHAR(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CondicaoDePagamentoEmDias",
                table: "SolicitacoesDeCompra");

            migrationBuilder.DropColumn(
                name: "NomeUsuarioSolicitante",
                table: "SolicitacoesDeCompra");

            migrationBuilder.AddColumn<Guid>(
                name: "NomeFornecedor_Id",
                table: "SolicitacoesDeCompra",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CondicaoDePgamentoId",
                table: "SolicitacoesDeCompra",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioSolicitanteId",
                table: "SolicitacoesDeCompra",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CondicaoDePagamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CondicaoEmDias = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondicaoDePagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioSolicitante",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioSolicitante", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacoesDeCompra_CondicaoDePgamentoId",
                table: "SolicitacoesDeCompra",
                column: "CondicaoDePgamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacoesDeCompra_UsuarioSolicitanteId",
                table: "SolicitacoesDeCompra",
                column: "UsuarioSolicitanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacoesDeCompra_CondicaoDePagamento_CondicaoDePgamentoId",
                table: "SolicitacoesDeCompra",
                column: "CondicaoDePgamentoId",
                principalTable: "CondicaoDePagamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacoesDeCompra_UsuarioSolicitante_UsuarioSolicitanteId",
                table: "SolicitacoesDeCompra",
                column: "UsuarioSolicitanteId",
                principalTable: "UsuarioSolicitante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
