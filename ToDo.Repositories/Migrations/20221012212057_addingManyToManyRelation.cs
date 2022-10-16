using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.Repositories.Migrations
{
    public partial class addingManyToManyRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoItemTool",
                columns: table => new
                {
                    TodoItemsId = table.Column<int>(type: "int", nullable: false),
                    ToolsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItemTool", x => new { x.TodoItemsId, x.ToolsId });
                    table.ForeignKey(
                        name: "FK_TodoItemTool_TodoItems_TodoItemsId",
                        column: x => x.TodoItemsId,
                        principalTable: "TodoItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TodoItemTool_Tools_ToolsId",
                        column: x => x.ToolsId,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoItemTool_ToolsId",
                table: "TodoItemTool",
                column: "ToolsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItemTool");
        }
    }
}
