using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntelliStocks.Migrations
{
    /// <inheritdoc />
    public partial class Migration_02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Endereco_EnderecoId",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produto",
                table: "Produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fornecedor",
                table: "Fornecedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "IntelliStocks_Usuario");

            migrationBuilder.RenameTable(
                name: "Produto",
                newName: "IntelliStocks_Produto");

            migrationBuilder.RenameTable(
                name: "Fornecedor",
                newName: "IntelliStocks_Fornecedor");

            migrationBuilder.RenameTable(
                name: "Endereco",
                newName: "IntelliStocks_Endereco");

            migrationBuilder.RenameTable(
                name: "Categoria",
                newName: "IntelliStocks_Categoria");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_EnderecoId",
                table: "IntelliStocks_Usuario",
                newName: "IX_IntelliStocks_Usuario_EnderecoId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "IntelliStocks_Produto",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IntelliStocks_Usuario",
                table: "IntelliStocks_Usuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IntelliStocks_Produto",
                table: "IntelliStocks_Produto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IntelliStocks_Fornecedor",
                table: "IntelliStocks_Fornecedor",
                column: "FornecedorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IntelliStocks_Endereco",
                table: "IntelliStocks_Endereco",
                column: "EnderecoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IntelliStocks_Categoria",
                table: "IntelliStocks_Categoria",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_IntelliStocks_Usuario_IntelliStocks_Endereco_EnderecoId",
                table: "IntelliStocks_Usuario",
                column: "EnderecoId",
                principalTable: "IntelliStocks_Endereco",
                principalColumn: "EnderecoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IntelliStocks_Usuario_IntelliStocks_Endereco_EnderecoId",
                table: "IntelliStocks_Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IntelliStocks_Usuario",
                table: "IntelliStocks_Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IntelliStocks_Produto",
                table: "IntelliStocks_Produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IntelliStocks_Fornecedor",
                table: "IntelliStocks_Fornecedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IntelliStocks_Endereco",
                table: "IntelliStocks_Endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IntelliStocks_Categoria",
                table: "IntelliStocks_Categoria");

            migrationBuilder.RenameTable(
                name: "IntelliStocks_Usuario",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "IntelliStocks_Produto",
                newName: "Produto");

            migrationBuilder.RenameTable(
                name: "IntelliStocks_Fornecedor",
                newName: "Fornecedor");

            migrationBuilder.RenameTable(
                name: "IntelliStocks_Endereco",
                newName: "Endereco");

            migrationBuilder.RenameTable(
                name: "IntelliStocks_Categoria",
                newName: "Categoria");

            migrationBuilder.RenameIndex(
                name: "IX_IntelliStocks_Usuario_EnderecoId",
                table: "Usuario",
                newName: "IX_Usuario_EnderecoId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Produto",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produto",
                table: "Produto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fornecedor",
                table: "Fornecedor",
                column: "FornecedorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                column: "EnderecoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Endereco_EnderecoId",
                table: "Usuario",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "EnderecoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
