using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntelliStocks.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IntelliStocks02_Produtos_IntelliStocks02_Categorias_CategoriaId",
                table: "IntelliStocks02_Produtos");

            migrationBuilder.DropIndex(
                name: "IX_IntelliStocks02_Produtos_CategoriaId",
                table: "IntelliStocks02_Produtos");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "IntelliStocks02_Produtos",
                newName: "Categoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Categoria",
                table: "IntelliStocks02_Produtos",
                newName: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_IntelliStocks02_Produtos_CategoriaId",
                table: "IntelliStocks02_Produtos",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_IntelliStocks02_Produtos_IntelliStocks02_Categorias_CategoriaId",
                table: "IntelliStocks02_Produtos",
                column: "CategoriaId",
                principalTable: "IntelliStocks02_Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
