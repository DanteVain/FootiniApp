using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FootiniApp.API.Migrations
{
    public partial class updatedimage24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Boards_BoardId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "BoardId",
                table: "Images",
                newName: "BoardsId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_BoardId",
                table: "Images",
                newName: "IX_Images_BoardsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Boards_BoardsId",
                table: "Images",
                column: "BoardsId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Boards_BoardsId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "BoardsId",
                table: "Images",
                newName: "BoardId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_BoardsId",
                table: "Images",
                newName: "IX_Images_BoardId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Images",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
