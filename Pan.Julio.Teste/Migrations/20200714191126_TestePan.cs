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
                    IdTipoCliente = table.Column<int>(nullable: false),
                    NmCliente = table.Column<string>(nullable: false),
                    NuDocumento = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "TipoLancamento",
                columns: table => new
                {
                    IdTipoLancamento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtCriacao = table.Column<DateTime>(nullable: false),
                    IcAtivo = table.Column<int>(nullable: false),
                    NmTipoLancamento = table.Column<string>(nullable: false)
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
                    NmTipoOperacao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoOperacao", x => x.IdTipoOperacao);
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
                    DtUltOperacao = table.Column<DateTime>(nullable: false),
                    ClienteIdCliente = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaCorrente", x => x.IdContaCorrente);
                    table.ForeignKey(
                        name: "FK_ContaCorrente_Cliente_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
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
                    VlOperacao = table.Column<decimal>(nullable: false),
                    TipoOperacaoIdTipoOperacao = table.Column<int>(nullable: true),
                    TipoLancamentoIdTipoLancamento = table.Column<int>(nullable: true),
                    ContaCorrenteIdContaCorrente = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamentos", x => x.IdLancamento);
                    table.ForeignKey(
                        name: "FK_Lancamentos_ContaCorrente_ContaCorrenteIdContaCorrente",
                        column: x => x.ContaCorrenteIdContaCorrente,
                        principalTable: "ContaCorrente",
                        principalColumn: "IdContaCorrente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lancamentos_TipoLancamento_TipoLancamentoIdTipoLancamento",
                        column: x => x.TipoLancamentoIdTipoLancamento,
                        principalTable: "TipoLancamento",
                        principalColumn: "IdTipoLancamento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lancamentos_TipoOperacao_TipoOperacaoIdTipoOperacao",
                        column: x => x.TipoOperacaoIdTipoOperacao,
                        principalTable: "TipoOperacao",
                        principalColumn: "IdTipoOperacao",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TipoLancamento",
                columns: new[] { "IdTipoLancamento", "DtCriacao", "IcAtivo", "NmTipoLancamento" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 7, 14, 16, 11, 25, 803, DateTimeKind.Local).AddTicks(4080), 1, "Débito" },
                    { 2, new DateTime(2020, 7, 14, 16, 11, 25, 805, DateTimeKind.Local).AddTicks(3852), 1, "Crédito" }
                });

            migrationBuilder.InsertData(
                table: "TipoOperacao",
                columns: new[] { "IdTipoOperacao", "DtCriacao", "IcAtivo", "NmTipoOperacao" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 7, 14, 16, 11, 25, 807, DateTimeKind.Local).AddTicks(4670), 1, "Transferencia" },
                    { 2, new DateTime(2020, 7, 14, 16, 11, 25, 807, DateTimeKind.Local).AddTicks(4749), 1, "Doc" },
                    { 3, new DateTime(2020, 7, 14, 16, 11, 25, 807, DateTimeKind.Local).AddTicks(4753), 1, "Ted" },
                    { 4, new DateTime(2020, 7, 14, 16, 11, 25, 807, DateTimeKind.Local).AddTicks(4755), 1, "Depósito" },
                    { 5, new DateTime(2020, 7, 14, 16, 11, 25, 807, DateTimeKind.Local).AddTicks(4757), 1, "Saque" },
                    { 6, new DateTime(2020, 7, 14, 16, 11, 25, 807, DateTimeKind.Local).AddTicks(4759), 1, "Pagamento" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContaCorrente_ClienteIdCliente",
                table: "ContaCorrente",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_ContaCorrenteIdContaCorrente",
                table: "Lancamentos",
                column: "ContaCorrenteIdContaCorrente");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_TipoLancamentoIdTipoLancamento",
                table: "Lancamentos",
                column: "TipoLancamentoIdTipoLancamento");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_TipoOperacaoIdTipoOperacao",
                table: "Lancamentos",
                column: "TipoOperacaoIdTipoOperacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lancamentos");

            migrationBuilder.DropTable(
                name: "ContaCorrente");

            migrationBuilder.DropTable(
                name: "TipoLancamento");

            migrationBuilder.DropTable(
                name: "TipoOperacao");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
