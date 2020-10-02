using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class IdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 2, 15, 0, 0, 925, DateTimeKind.Local).AddTicks(5516),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 10, 1, 10, 58, 27, 1, DateTimeKind.Local).AddTicks(5703));

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("8b834efc-c1ed-4037-9ebb-247ba7935056"), "53e152d4-9860-489d-b6f3-7f8ca0241305", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("68dd56fc-de75-4ba9-a249-293cbf1f9b04"), new Guid("8b834efc-c1ed-4037-9ebb-247ba7935056") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("68dd56fc-de75-4ba9-a249-293cbf1f9b04"), 0, "85b07c13-3736-4885-aa2b-9c0b527e418e", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "tedu.international@gmail.com", true, "Quan", "Nguyen", false, null, "tedu.international@gmail.com", "admin", "AQAAAAEAACcQAAAAEJ4yWeOyA4yOQ+CQFIqYzLZ8xbBm68gbu9zKZB7Kh/9FvsfqtxmOPdCR3+0J3C87hw==", null, false, "", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 10, 2, 15, 0, 0, 946, DateTimeKind.Local).AddTicks(2369));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8b834efc-c1ed-4037-9ebb-247ba7935056"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("68dd56fc-de75-4ba9-a249-293cbf1f9b04"), new Guid("8b834efc-c1ed-4037-9ebb-247ba7935056") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("68dd56fc-de75-4ba9-a249-293cbf1f9b04"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 1, 10, 58, 27, 1, DateTimeKind.Local).AddTicks(5703),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 10, 2, 15, 0, 0, 925, DateTimeKind.Local).AddTicks(5516));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 10, 1, 10, 58, 27, 17, DateTimeKind.Local).AddTicks(777));
        }
    }
}
