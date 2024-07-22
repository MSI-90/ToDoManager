using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoManager.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationsOnUserCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_usercategory_UserCategoryUserId_UserCategoryCat~",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_categories_usercategory_UserCategoryUserId_UserCategoryCate~",
                table: "categories");

            migrationBuilder.DropIndex(
                name: "IX_categories_UserCategoryUserId_UserCategoryCategoryId",
                table: "categories");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserCategoryUserId_UserCategoryCategoryId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserCategoryCategoryId",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "UserCategoryUserId",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "UserCategoryCategoryId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserCategoryUserId",
                table: "AspNetUsers");

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

            migrationBuilder.AddForeignKey(
                name: "FK_usercategory_AspNetUsers_user_id",
                table: "usercategory",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usercategory_categories_category_id",
                table: "usercategory",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usercategory_AspNetUsers_user_id",
                table: "usercategory");

            migrationBuilder.DropForeignKey(
                name: "FK_usercategory_categories_category_id",
                table: "usercategory");

            migrationBuilder.DropIndex(
                name: "IX_usercategory_category_id",
                table: "usercategory");

            migrationBuilder.AddColumn<Guid>(
                name: "UserCategoryCategoryId",
                table: "categories",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCategoryUserId",
                table: "categories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserCategoryCategoryId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCategoryUserId",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ffabf88-601d-4840-ad89-1d50683d87c1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserCategoryCategoryId", "UserCategoryUserId" },
                values: new object[] { "21415831-2150-4180-9e4b-50893fed79fe", "5a0fdbe4-7956-4dec-9340-d30562b44369", null, null });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "category_id",
                keyValue: new Guid("c3d4c014-49b6-410c-bc78-1d54a9991870"),
                columns: new[] { "UserCategoryCategoryId", "UserCategoryUserId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "tasks",
                keyColumn: "task_id",
                keyValue: new Guid("60abbca8-664d-4b20-b5de-024705497d4a"),
                column: "creation_date",
                value: new DateTime(2024, 7, 15, 7, 33, 47, 405, DateTimeKind.Utc).AddTicks(278));

            migrationBuilder.CreateIndex(
                name: "IX_categories_UserCategoryUserId_UserCategoryCategoryId",
                table: "categories",
                columns: new[] { "UserCategoryUserId", "UserCategoryCategoryId" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserCategoryUserId_UserCategoryCategoryId",
                table: "AspNetUsers",
                columns: new[] { "UserCategoryUserId", "UserCategoryCategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_usercategory_UserCategoryUserId_UserCategoryCat~",
                table: "AspNetUsers",
                columns: new[] { "UserCategoryUserId", "UserCategoryCategoryId" },
                principalTable: "usercategory",
                principalColumns: new[] { "user_id", "category_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_categories_usercategory_UserCategoryUserId_UserCategoryCate~",
                table: "categories",
                columns: new[] { "UserCategoryUserId", "UserCategoryCategoryId" },
                principalTable: "usercategory",
                principalColumns: new[] { "user_id", "category_id" });
        }
    }
}
