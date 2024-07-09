using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoManager.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPropertyAsIsCancelledForTaskItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                table: "tasks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ffabf88-601d-4840-ad89-1d50683d87c1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "20cec08a-1534-4438-8b35-d5f0e04eaf29", "01edd875-0352-4d27-beae-5355df307c01" });

            migrationBuilder.UpdateData(
                table: "tasks",
                keyColumn: "task_id",
                keyValue: new Guid("60abbca8-664d-4b20-b5de-024705497d4a"),
                columns: new[] { "creation_date", "IsCancelled" },
                values: new object[] { new DateTime(2024, 7, 9, 12, 51, 43, 331, DateTimeKind.Utc).AddTicks(8066), true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCancelled",
                table: "tasks");

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
        }
    }
}
