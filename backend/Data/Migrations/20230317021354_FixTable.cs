using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class FixTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdeaDetail");

            migrationBuilder.CreateTable(
                name: "IdeaCategories",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    IdeasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdeaCategories", x => new { x.CategoriesId, x.IdeasId });
                    table.ForeignKey(
                        name: "FK_IdeaCategories_Category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdeaCategories_Idea_IdeasId",
                        column: x => x.IdeasId,
                        principalTable: "Idea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdeaCategories_IdeasId",
                table: "IdeaCategories",
                column: "IdeasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdeaCategories");

            migrationBuilder.CreateTable(
                name: "IdeaDetail",
                columns: table => new
                {
                    IdeaId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdeaDetail", x => new { x.IdeaId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_IdeaDetail_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IdeaDetail_Idea_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Idea",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdeaDetail_CategoryId",
                table: "IdeaDetail",
                column: "CategoryId");
        }
    }
}
