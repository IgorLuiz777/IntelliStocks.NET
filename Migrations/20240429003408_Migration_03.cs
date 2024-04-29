using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntelliStocks.Migrations
{
    /// <inheritdoc />
    public partial class Migration_03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IntelliStocks_Usuario_IntelliStocks_Endereco_EnderecoId",
                table: "IntelliStocks_Usuario");

            migrationBuilder.DropIndex(
                name: "IX_IntelliStocks_Usuario_EnderecoId",
                table: "IntelliStocks_Usuario");

            migrationBuilder.RenameColumn(
                name: "EnderecoId",
                table: "IntelliStocks_Usuario",
                newName: "EnderecoID");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "IntelliStocks_Produto",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EnderecoID",
                table: "IntelliStocks_Usuario",
                newName: "EnderecoId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "IntelliStocks_Produto",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.CreateIndex(
                name: "IX_IntelliStocks_Usuario_EnderecoId",
                table: "IntelliStocks_Usuario",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_IntelliStocks_Usuario_IntelliStocks_Endereco_EnderecoId",
                table: "IntelliStocks_Usuario",
                column: "EnderecoId",
                principalTable: "IntelliStocks_Endereco",
                principalColumn: "EnderecoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
