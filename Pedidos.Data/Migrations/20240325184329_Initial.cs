using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pedidos.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeRazaoSocial = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    EmailContato = table.Column<string>(nullable: true),
                    NomeContato = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    ValorProduto = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false, defaultValue: "TesteTemplate"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FornecedorId = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false),
                    DataPedido = table.Column<DateTime>(nullable: false),
                    QuantidadeProdutos = table.Column<int>(nullable: false),
                    ValorTotalPedido = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Fornecedores",
                columns: new[] { "Id", "CNPJ", "EmailContato", "NomeContato", "NomeRazaoSocial", "UF" },
                values: new object[] { 1, "86673673000128", "fiscal@franciscoecarloscomerciodebebidasme.com.br", "Juca", "Francisco e Carlos Comercio de Bebidas ME", "DF" });

            migrationBuilder.InsertData(
                table: "Fornecedores",
                columns: new[] { "Id", "CNPJ", "EmailContato", "NomeContato", "NomeRazaoSocial", "UF" },
                values: new object[] { 2, "55738477000160", "auditoria@isabellyemanoelpizzarialtda.com.br", "Isabelly", "Isabelly e Manoel Pizzaria Ltda", "DF" });

            migrationBuilder.InsertData(
                table: "Fornecedores",
                columns: new[] { "Id", "CNPJ", "EmailContato", "NomeContato", "NomeRazaoSocial", "UF" },
                values: new object[] { 3, "07805502000139", "fiscal@sebastiaoegeraldograficame.com.br", "Sebastião", "Sebastião e Geraldo Gráfica ME", "DF" });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "DataCadastro", "Descricao", "ValorProduto" },
                values: new object[] { 1, new DateTime(2024, 3, 25, 15, 43, 29, 489, DateTimeKind.Local).AddTicks(9230), "água", 10m });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "DataCadastro", "Descricao", "ValorProduto" },
                values: new object[] { 2, new DateTime(2024, 3, 25, 15, 43, 29, 490, DateTimeKind.Local).AddTicks(5725), "terra", 1000m });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "DataCadastro", "Descricao", "ValorProduto" },
                values: new object[] { 3, new DateTime(2024, 3, 25, 15, 43, 29, 490, DateTimeKind.Local).AddTicks(5749), "tijolo", 5000m });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "Email", "IsDeleted", "Name" },
                values: new object[] { 1, new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "userdefault@Pedidos.com", false, "User Default" });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "Id", "DataPedido", "FornecedorId", "ProdutoId", "QuantidadeProdutos", "ValorTotalPedido" },
                values: new object[] { 1, new DateTime(2024, 3, 25, 15, 43, 29, 490, DateTimeKind.Local).AddTicks(7682), 1, 1, 5, 0m });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "Id", "DataPedido", "FornecedorId", "ProdutoId", "QuantidadeProdutos", "ValorTotalPedido" },
                values: new object[] { 2, new DateTime(2024, 3, 25, 15, 43, 29, 490, DateTimeKind.Local).AddTicks(7862), 2, 2, 5, 0m });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "Id", "DataPedido", "FornecedorId", "ProdutoId", "QuantidadeProdutos", "ValorTotalPedido" },
                values: new object[] { 3, new DateTime(2024, 3, 25, 15, 43, 29, 490, DateTimeKind.Local).AddTicks(7868), 3, 3, 5, 0m });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_FornecedorId",
                table: "Pedidos",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ProdutoId",
                table: "Pedidos",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
