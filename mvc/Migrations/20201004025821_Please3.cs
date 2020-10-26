using Microsoft.EntityFrameworkCore.Migrations;

namespace mvc.Migrations
{
    public partial class Please3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Post_PostId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostViewModelPostId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PostViewModel",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(nullable: false),
                    CommentsId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostViewModel", x => x.PostId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostViewModelPostId",
                table: "Comments",
                column: "PostViewModelPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Post_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_PostViewModel_PostViewModelPostId",
                table: "Comments",
                column: "PostViewModelPostId",
                principalTable: "PostViewModel",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Post_PostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_PostViewModel_PostViewModelPostId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "PostViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostViewModelPostId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PostViewModelPostId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Post_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
