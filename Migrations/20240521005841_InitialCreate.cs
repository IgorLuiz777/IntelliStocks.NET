using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntelliStocks.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IntelliStocks02_Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntelliStocks02_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "IntelliStocks02_Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    CPF = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntelliStocks02_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntelliStocks02_Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Preco = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Modelo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Marca = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Quantidade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CategoriaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntelliStocks02_Produtos", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_IntelliStocks02_Produtos_IntelliStocks02_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "IntelliStocks02_Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IntelliStocks02_Produtos_CategoriaId",
                table: "IntelliStocks02_Produtos",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntelliStocks02_Produtos");

            migrationBuilder.DropTable(
                name: "IntelliStocks02_Usuario");

            migrationBuilder.DropTable(
                name: "IntelliStocks02_Categorias");
        }
    }
}
