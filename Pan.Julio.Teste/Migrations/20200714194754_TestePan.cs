using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pan.Julio.Teste.Migrations
{
    public partial class TestePan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtCriacao = table.Column<DateTime>(nullable: false),
                    IcAtivo = table.Column<int>(nullable: false),
                    IcPessoaFisica = table.Column<bool>(nullable: false),
                    NmCliente = table.Column<string>(maxLength: 50, nullable: false),
                    NuDocumento = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "ContaCorrente",
                columns: table => new
                {
                    IdContaCorrente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtCriacao = table.Column<DateTime>(nullable: false),
                    IcAtivo = table.Column<int>(nullable: false),
                    IdCliente = table.Column<int>(nullable: false),
                    DtAbertura = table.Column<DateTime>(nullable: false),
                    VlSaldo = table.Column<decimal>(nullable: false),
                    DtUltOperacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaCorrente", x => x.IdContaCorrente);
                });

            migrationBuilder.CreateTable(
                name: "Lancamentos",
                columns: table => new
                {
                    IdLancamento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtCriacao = table.Column<DateTime>(nullable: false),
                    IcAtivo = table.Column<int>(nullable: false),
                    IdContaCorrente = table.Column<int>(nullable: false),
                    IdTipoOperacao = table.Column<int>(nullable: false),
                    IdTipoLancamento = table.Column<int>(nullable: false),
                    DtOperacao = table.Column<DateTime>(nullable: false),
                    VlOperacao = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamentos", x => x.IdLancamento);
                });

            migrationBuilder.CreateTable(
                name: "TipoLancamento",
                columns: table => new
                {
                    IdTipoLancamento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtCriacao = table.Column<DateTime>(nullable: false),
                    IcAtivo = table.Column<int>(nullable: false),
                    NmTipoLancamento = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoLancamento", x => x.IdTipoLancamento);
                });

            migrationBuilder.CreateTable(
                name: "TipoOperacao",
                columns: table => new
                {
                    IdTipoOperacao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtCriacao = table.Column<DateTime>(nullable: false),
                    IcAtivo = table.Column<int>(nullable: false),
                    NmTipoOperacao = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoOperacao", x => x.IdTipoOperacao);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "IdCliente", "DtCriacao", "IcAtivo", "IcPessoaFisica", "NmCliente", "NuDocumento" },
                values: new object[] { 1, new DateTime(2020, 7, 14, 16, 47, 53, 680, DateTimeKind.Local).AddTicks(2367), 1, true, "Julio Cesar Fretes", "11111111111" });

            migrationBuilder.InsertData(
                table: "ContaCorrente",
                columns: new[] { "IdContaCorrente", "DtAbertura", "DtCriacao", "DtUltOperacao", "IcAtivo", "IdCliente", "VlSaldo" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 7, 14, 16, 47, 53, 680, DateTimeKind.Local).AddTicks(4485), new DateTime(2020, 7, 14, 16, 47, 53, 680, DateTimeKind.Local).AddTicks(5879), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1000m },
                    { 2, new DateTime(2020, 7, 14, 16, 47, 53, 680, DateTimeKind.Local).AddTicks(6134), new DateTime(2020, 7, 14, 16, 47, 53, 680, DateTimeKind.Local).AddTicks(6168), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1000m }
                });

            migrationBuilder.InsertData(
                table: "TipoLancamento",
                columns: new[] { "IdTipoLancamento", "DtCriacao", "IcAtivo", "NmTipoLancamento" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 7, 14, 16, 47, 53, 676, DateTimeKind.Local).AddTicks(1462), 1, "Débito" },
                    { 2, new DateTime(2020, 7, 14, 16, 47, 53, 677, DateTimeKind.Local).AddTicks(8879), 1, "Crédito" }
                });

            migrationBuilder.InsertData(
                table: "TipoOperacao",
                columns: new[] { "IdTipoOperacao", "DtCriacao", "IcAtivo", "NmTipoOperacao" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 7, 14, 16, 47, 53, 679, DateTimeKind.Local).AddTicks(8665), 1, "Transferencia" },
                    { 2, new DateTime(2020, 7, 14, 16, 47, 53, 679, DateTimeKind.Local).AddTicks(8730), 1, "Doc" },
                    { 3, new DateTime(2020, 7, 14, 16, 47, 53, 679, DateTimeKind.Local).AddTicks(8734), 1, "Ted" },
                    { 4, new DateTime(2020, 7, 14, 16, 47, 53, 679, DateTimeKind.Local).AddTicks(8737), 1, "Depósito" },
                    { 5, new DateTime(2020, 7, 14, 16, 47, 53, 679, DateTimeKind.Local).AddTicks(8740), 1, "Saque" },
                    { 6, new DateTime(2020, 7, 14, 16, 47, 53, 679, DateTimeKind.Local).AddTicks(8742), 1, "Pagamento" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "ContaCorrente");

            migrationBuilder.DropTable(
                name: "Lancamentos");

            migrationBuilder.DropTable(
                name: "TipoLancamento");

            migrationBuilder.DropTable(
                name: "TipoOperacao");
        }
    }
}
