using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpowerHealthyStudents.Migrations
{
    public partial class product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f84ef977-aba9-4ab8-a611-810cacad1de1", "AQAAAAEAACcQAAAAEP+EKKBi7kt1eM748qymk/T/C4wwYQKd35S2gcuU8elR6ZV0dtWi3j7uc2RI+f22lg==" });

            migrationBuilder.InsertData(
                table: "ProductReview",
                columns: new[] { "Id", "Comment", "ProductId", "UserId" },
                values: new object[] { 1, "You are a Godsend.", 1, "10000000-ffff-ffff-ffff-ffffffffffff" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductReview",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6a0228a5-996f-4434-b712-57ba6029aa03", "AQAAAAEAACcQAAAAEKijrWTacw17iI0I6DCayhA8Ww36JFGyC3M1GpHAjOxsCed1QPxLlEbQ4dZ2xwT5Eg==" });
        }
    }
}
