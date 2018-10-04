using Microsoft.EntityFrameworkCore.Migrations;

namespace FootiniApp.API.Migrations
{
    public partial class updatedimage25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Boards_BoardsId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Users_UserId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "BoardsId",
                table: "Images",
                newName: "BoardId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_BoardsId",
                table: "Images",
                newName: "IX_Images_BoardId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Images",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Boards_BoardId",
                table: "Images",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Users_UserId",
                table: "Images",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Boards_BoardId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Users_UserId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "BoardId",
                table: "Images",
                newName: "BoardsId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_BoardId",
                table: "Images",
                newName: "IX_Images_BoardsId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Images",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Boards_BoardsId",
                table: "Images",
                column: "BoardsId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Users_UserId",
                table: "Images",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
