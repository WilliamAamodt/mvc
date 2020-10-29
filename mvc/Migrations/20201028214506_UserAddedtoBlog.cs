using Microsoft.EntityFrameworkCore.Migrations;

namespace mvc.Migrations
{
    public partial class UserAddedtoBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Blog",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blog_UserId",
                table: "Blog",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Users_UserId",
                table: "Blog",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Users_UserId",
                table: "Blog");

            migrationBuilder.DropIndex(
                name: "IX_Blog_UserId",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Blog");
        }
    }
}
