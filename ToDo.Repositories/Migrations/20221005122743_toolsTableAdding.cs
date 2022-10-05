using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.Repositories.Migrations
{
    public partial class toolsTableAdding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_List2Do_Users_CreatedUserId",
                table: "List2Do");

            migrationBuilder.DropForeignKey(
                name: "FK_List2Do_Users_ResponsibleUserId",
                table: "List2Do");

            migrationBuilder.DropForeignKey(
                name: "FK_List2Do_Users_UpdatdeUserId",
                table: "List2Do");

            migrationBuilder.DropPrimaryKey(
                name: "PK_List2Do",
                table: "List2Do");

            migrationBuilder.RenameTable(
                name: "List2Do",
                newName: "TodoItems");

            migrationBuilder.RenameIndex(
                name: "IX_List2Do_UpdatdeUserId",
                table: "TodoItems",
                newName: "IX_TodoItems_UpdatdeUserId");

            migrationBuilder.RenameIndex(
                name: "IX_List2Do_ResponsibleUserId",
                table: "TodoItems",
                newName: "IX_TodoItems_ResponsibleUserId");

            migrationBuilder.RenameIndex(
                name: "IX_List2Do_CreatedUserId",
                table: "TodoItems",
                newName: "IX_TodoItems_CreatedUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoItems",
                table: "TodoItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Users_CreatedUserId",
                table: "TodoItems",
                column: "CreatedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Users_ResponsibleUserId",
                table: "TodoItems",
                column: "ResponsibleUserId",
                principalTable: "Users",
                principalColumn: "Id");

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
                name: "FK_TodoItems_Users_CreatedUserId",
                table: "TodoItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Users_ResponsibleUserId",
                table: "TodoItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Users_UpdatdeUserId",
                table: "TodoItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoItems",
                table: "TodoItems");

            migrationBuilder.RenameTable(
                name: "TodoItems",
                newName: "List2Do");

            migrationBuilder.RenameIndex(
                name: "IX_TodoItems_UpdatdeUserId",
                table: "List2Do",
                newName: "IX_List2Do_UpdatdeUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TodoItems_ResponsibleUserId",
                table: "List2Do",
                newName: "IX_List2Do_ResponsibleUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TodoItems_CreatedUserId",
                table: "List2Do",
                newName: "IX_List2Do_CreatedUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_List2Do",
                table: "List2Do",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_List2Do_Users_CreatedUserId",
                table: "List2Do",
                column: "CreatedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_List2Do_Users_ResponsibleUserId",
                table: "List2Do",
                column: "ResponsibleUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_List2Do_Users_UpdatdeUserId",
                table: "List2Do",
                column: "UpdatdeUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
