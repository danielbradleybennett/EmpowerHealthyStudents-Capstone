using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpowerHealthyStudents.Migrations
{
    public partial class pics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "63289863-0010-4976-9e77-9bb1052dc8d3", "AQAAAAEAACcQAAAAEO/w6T2Ar/qXwhmF9qH4+aHD6vxfrmsUzUErnBNPosn2VDURDZu7NvJFAHE+FcjrLQ==" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "File",
                value: "Mind_flayer.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f84ef977-aba9-4ab8-a611-810cacad1de1", "AQAAAAEAACcQAAAAEP+EKKBi7kt1eM748qymk/T/C4wwYQKd35S2gcuU8elR6ZV0dtWi3j7uc2RI+f22lg==" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "File",
                value: null);
        }
    }
}
