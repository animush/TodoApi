using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.Repositories.Migrations
{
    public partial class addResponsibleUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResponsibleUserId",
                table: "TodoItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_ResponsibleUserId",
                table: "TodoItems",
                column: "ResponsibleUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Users_ResponsibleUserId",
                table: "TodoItems",
                column: "ResponsibleUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Users_ResponsibleUserId",
                table: "TodoItems");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_ResponsibleUserId",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "ResponsibleUserId",
                table: "TodoItems");
        }
    }
}
