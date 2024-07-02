using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoManager.Migrations
{
    /// <inheritdoc />
    public partial class CreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    category_title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "tasks",
                columns: table => new
                {
                    task_id = table.Column<Guid>(type: "uuid", nullable: false),
                    task_title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    priority = table.Column<byte>(type: "smallint", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks", x => x.task_id);
                    table.ForeignKey(
                        name: "FK_tasks_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "category_id", "description", "category_title" },
                values: new object[] { new Guid("c3d4c014-49b6-410c-bc78-1d54a9991870"), "Здесь как правило нет каких то значимых дел", "Досуг" });

            migrationBuilder.InsertData(
                table: "tasks",
                columns: new[] { "task_id", "category_id", "description", "priority", "task_title" },
                values: new object[] { new Guid("60abbca8-664d-4b20-b5de-024705497d4a"), new Guid("c3d4c014-49b6-410c-bc78-1d54a9991870"), "Пить кофе весело, пить кофе хорошо)", (byte)1, "Попить кофе" });

            migrationBuilder.CreateIndex(
                name: "IX_tasks_category_id",
                table: "tasks",
                column: "category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tasks");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
