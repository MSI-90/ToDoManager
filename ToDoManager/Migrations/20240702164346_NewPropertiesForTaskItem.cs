using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoManager.Migrations
{
    /// <inheritdoc />
    public partial class NewPropertiesForTaskItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "creation_date",
                table: "tasks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "expiration_date",
                table: "tasks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "tasks",
                keyColumn: "task_id",
                keyValue: new Guid("60abbca8-664d-4b20-b5de-024705497d4a"),
                columns: new[] { "creation_date", "expiration_date" },
                values: new object[] { new DateTime(2024, 7, 2, 16, 43, 46, 516, DateTimeKind.Utc).AddTicks(8536), new DateTime(2024, 7, 6, 23, 34, 42, 361, DateTimeKind.Utc).AddTicks(7996) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "creation_date",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "expiration_date",
                table: "tasks");
        }
    }
}
