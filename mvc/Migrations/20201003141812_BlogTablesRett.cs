using Microsoft.EntityFrameworkCore.Migrations;

namespace mvc.Migrations
{
    public partial class BlogTablesRett : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Blog",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Blog",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Blog");
        }
    }
}
