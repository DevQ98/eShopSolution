using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class UpdateData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 7, 18, 48, 35, 738, DateTimeKind.Local).AddTicks(5739),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 10, 2, 15, 0, 0, 925, DateTimeKind.Local).AddTicks(5516));

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    Caption = table.Column<string>(maxLength: 200, nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    FileSize = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8b834efc-c1ed-4037-9ebb-247ba7935056"),
                column: "ConcurrencyStamp",
                value: "a69c31f2-4932-446e-a199-ee0c623f3743");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("68dd56fc-de75-4ba9-a249-293cbf1f9b04"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1c8708e9-be38-43ee-8074-d69867cd0400", "AQAAAAEAACcQAAAAEMh70s+FbTh0lIafHGJAPKchsMHnq4ep2kv404Kvv/PcAGyZY1JfTFU1oN0KrhLzDw==" });

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
                value: new DateTime(2020, 10, 7, 18, 48, 35, 756, DateTimeKind.Local).AddTicks(4285));

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 2, 15, 0, 0, 925, DateTimeKind.Local).AddTicks(5516),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 10, 7, 18, 48, 35, 738, DateTimeKind.Local).AddTicks(5739));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8b834efc-c1ed-4037-9ebb-247ba7935056"),
                column: "ConcurrencyStamp",
                value: "53e152d4-9860-489d-b6f3-7f8ca0241305");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("68dd56fc-de75-4ba9-a249-293cbf1f9b04"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "85b07c13-3736-4885-aa2b-9c0b527e418e", "AQAAAAEAACcQAAAAEJ4yWeOyA4yOQ+CQFIqYzLZ8xbBm68gbu9zKZB7Kh/9FvsfqtxmOPdCR3+0J3C87hw==" });

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
    }
}
