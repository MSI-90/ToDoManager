using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoManager.Migrations
{
    /// <inheritdoc />
    public partial class UppdateUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sername",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "AspNetUsers",
                newName: "FirstName");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ffabf88-601d-4840-ad89-1d50683d87c1",
                columns: new[] { "ConcurrencyStamp", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "abcfdf5c-9d78-4afc-af62-17415ecc4b95", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "da662ac4-0e01-40d9-aafd-4586cb87c1bd" });

            migrationBuilder.UpdateData(
                table: "tasks",
                keyColumn: "task_id",
                keyValue: new Guid("60abbca8-664d-4b20-b5de-024705497d4a"),
                column: "creation_date",
                value: new DateTime(2024, 7, 7, 17, 3, 54, 267, DateTimeKind.Utc).AddTicks(219));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "sername");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "AspNetUsers",
                newName: "name");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ffabf88-601d-4840-ad89-1d50683d87c1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "63bf5f68-6a76-440f-8762-7add7049822a", "0c251269-9e13-4a73-a14b-2c368827e7a2" });

            migrationBuilder.UpdateData(
                table: "tasks",
                keyColumn: "task_id",
                keyValue: new Guid("60abbca8-664d-4b20-b5de-024705497d4a"),
                column: "creation_date",
                value: new DateTime(2024, 7, 4, 11, 12, 26, 343, DateTimeKind.Utc).AddTicks(3063));
        }
    }
}
