using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INTELLISTOCKS.MODELS.Migrations
{
    /// <inheritdoc />
    public partial class CreateTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "INTELLISTOCKS_TASKS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Title = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    DueTo = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Priority = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INTELLISTOCKS_TASKS", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "INTELLISTOCKS_TASKS");
        }
    }
}
