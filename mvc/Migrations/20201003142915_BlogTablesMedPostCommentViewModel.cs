using Microsoft.EntityFrameworkCore.Migrations;

namespace mvc.Migrations
{
    public partial class BlogTablesMedPostCommentViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blog_BlogId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BlogId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Blog");

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Post",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Postid",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Postid",
                table: "Comments",
                column: "Postid");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Post_Postid",
                table: "Comments",
                column: "Postid",
                principalTable: "Post",
                principalColumn: "Postid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Post_Postid",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_Postid",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Postid",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Blog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogId",
                table: "Comments",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blog_BlogId",
                table: "Comments",
                column: "BlogId",
                principalTable: "Blog",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
