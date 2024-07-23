using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoManager.Migrations
{
    /// <inheritdoc />
    public partial class DeleteUserCategory_ModifiedCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usercategory");

            migrationBuilder.AddColumn<Guid>(
                name: "Userid",
                table: "categories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ffabf88-601d-4840-ad89-1d50683d87c1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b63a07d5-545d-4aab-ba10-42e450f21d68", "86a30bad-c145-469a-8080-99fefb18afd4" });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "category_id",
                keyValue: new Guid("c3d4c014-49b6-410c-bc78-1d54a9991870"),
                column: "Userid",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "tasks",
                keyColumn: "task_id",
                keyValue: new Guid("60abbca8-664d-4b20-b5de-024705497d4a"),
                column: "creation_date",
                value: new DateTime(2024, 7, 23, 17, 31, 40, 248, DateTimeKind.Utc).AddTicks(7063));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Userid",
                table: "categories");

            migrationBuilder.CreateTable(
                name: "usercategory",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "text", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usercategory", x => new { x.user_id, x.category_id });
                    table.ForeignKey(
                        name: "FK_usercategory_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usercategory_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ffabf88-601d-4840-ad89-1d50683d87c1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1200a81f-3edc-4430-9eb1-03d8b47dd862", "f735f29f-d76d-4606-93d5-0e920ec0ba72" });

            migrationBuilder.UpdateData(
                table: "tasks",
                keyColumn: "task_id",
                keyValue: new Guid("60abbca8-664d-4b20-b5de-024705497d4a"),
                column: "creation_date",
                value: new DateTime(2024, 7, 22, 10, 3, 29, 581, DateTimeKind.Utc).AddTicks(1803));

            migrationBuilder.CreateIndex(
                name: "IX_usercategory_category_id",
                table: "usercategory",
                column: "category_id");
        }
    }
}
