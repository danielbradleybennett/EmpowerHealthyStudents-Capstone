using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpowerHealthyStudents.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogPostViewModelsId",
                table: "BlogComment",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9ef0577b-e0b1-4ce2-8b6f-3ef14986c530", "AQAAAAEAACcQAAAAEMlYoEYGAJTKmBV3SeaY2MBKtJnvEp4HSknnCIB3F9EqZKVsLvDKTCMMcHKalvmuRA==" });

            migrationBuilder.CreateIndex(
                name: "IX_BlogComment_BlogPostViewModelsId",
                table: "BlogComment",
                column: "BlogPostViewModelsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComment_BlogPostViewModels_BlogPostViewModelsId",
                table: "BlogComment",
                column: "BlogPostViewModelsId",
                principalTable: "BlogPostViewModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogComment_BlogPostViewModels_BlogPostViewModelsId",
                table: "BlogComment");

            migrationBuilder.DropIndex(
                name: "IX_BlogComment_BlogPostViewModelsId",
                table: "BlogComment");

            migrationBuilder.DropColumn(
                name: "BlogPostViewModelsId",
                table: "BlogComment");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c0ac0b14-1afb-42b8-9bf7-416fa26dce36", "AQAAAAEAACcQAAAAEJeMsELo0tb6aWvAfQAWCHMRd+97jjvTmju+wrC4aFZvTRJdNfYBVuNOyoLme7XS/g==" });
        }
    }
}
