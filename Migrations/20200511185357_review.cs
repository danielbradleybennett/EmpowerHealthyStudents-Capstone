using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpowerHealthyStudents.Migrations
{
    public partial class review : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductReview",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReview_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductReview_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6a0228a5-996f-4434-b712-57ba6029aa03", "AQAAAAEAACcQAAAAEKijrWTacw17iI0I6DCayhA8Ww36JFGyC3M1GpHAjOxsCed1QPxLlEbQ4dZ2xwT5Eg==" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_ProductId",
                table: "ProductReview",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_UserId",
                table: "ProductReview",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductReview");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d311b9b2-c9a8-43ac-87a7-de3ccc42dd58", "AQAAAAEAACcQAAAAEA16TJX6LWjPDkOayaLM45c6FdjlKjWEmv1ECR2qSV4hOjQ+ex4aLtgBJ0KATMddTA==" });
        }
    }
}
