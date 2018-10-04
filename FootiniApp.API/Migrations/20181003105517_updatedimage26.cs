using Microsoft.EntityFrameworkCore.Migrations;

namespace FootiniApp.API.Migrations
{
    public partial class updatedimage26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Boards_BoardId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_BoardId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "ImagesArray",
                table: "Boards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagesArray",
                table: "Boards");

            migrationBuilder.AddColumn<int>(
                name: "BoardId",
                table: "Images",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_BoardId",
                table: "Images",
                column: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Boards_BoardId",
                table: "Images",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
