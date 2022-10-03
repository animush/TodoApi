using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.Repositories.Migrations
{
    public partial class changeModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpatededDate",
                table: "TodoItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatdeUserId",
                table: "TodoItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_UpdatdeUserId",
                table: "TodoItems",
                column: "UpdatdeUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Users_UpdatdeUserId",
                table: "TodoItems",
                column: "UpdatdeUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Users_UpdatdeUserId",
                table: "TodoItems");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_UpdatdeUserId",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "UpatededDate",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "UpdatdeUserId",
                table: "TodoItems");
        }
    }
}
