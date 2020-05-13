using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpowerHealthyStudents.Migrations
{
    public partial class file : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fe342d1a-d6ce-4273-98f8-40c10b2949f8", "AQAAAAEAACcQAAAAEAWIHW3zBOi+2h00AKS+MB4ElN2OuqVI90SE+y28yZk7oTYlIoVx/QTPNPSGDT7HlQ==" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "Mind_flayer.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                column: "Image",
                value: null);
        }
    }
}
