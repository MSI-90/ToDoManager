using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoManager.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCategoryIdToNULLvailable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_categories_category_id",
                table: "tasks");

            migrationBuilder.AlterColumn<Guid>(
                name: "category_id",
                table: "tasks",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ffabf88-601d-4840-ad89-1d50683d87c1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "54f67122-f43a-412c-af32-677d1a819db5", "3becfa98-1b04-4a81-b658-2a33705a294d" });

            migrationBuilder.UpdateData(
                table: "tasks",
                keyColumn: "task_id",
                keyValue: new Guid("60abbca8-664d-4b20-b5de-024705497d4a"),
                column: "creation_date",
                value: new DateTime(2024, 7, 9, 6, 22, 3, 761, DateTimeKind.Utc).AddTicks(4422));

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_categories_category_id",
                table: "tasks",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_categories_category_id",
                table: "tasks");

            migrationBuilder.AlterColumn<Guid>(
                name: "category_id",
                table: "tasks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ffabf88-601d-4840-ad89-1d50683d87c1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "abcfdf5c-9d78-4afc-af62-17415ecc4b95", "da662ac4-0e01-40d9-aafd-4586cb87c1bd" });

            migrationBuilder.UpdateData(
                table: "tasks",
                keyColumn: "task_id",
                keyValue: new Guid("60abbca8-664d-4b20-b5de-024705497d4a"),
                column: "creation_date",
                value: new DateTime(2024, 7, 7, 17, 3, 54, 267, DateTimeKind.Utc).AddTicks(219));

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_categories_category_id",
                table: "tasks",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
