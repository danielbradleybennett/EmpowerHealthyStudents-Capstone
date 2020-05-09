using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpowerHealthyStudents.Migrations
{
    public partial class images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "File",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Product",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d311b9b2-c9a8-43ac-87a7-de3ccc42dd58", "AQAAAAEAACcQAAAAEA16TJX6LWjPDkOayaLM45c6FdjlKjWEmv1ECR2qSV4hOjQ+ex4aLtgBJ0KATMddTA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "File",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e99f86e3-bc8b-497e-a3a9-c77b90a2ffbd", "AQAAAAEAACcQAAAAEEwbApydFHMZWiNUyfUHbHpgaa1HwT1UXyzIPwuRXAK81bWBbNUvYIVyNxj6S3nZuQ==" });
        }
    }
}
