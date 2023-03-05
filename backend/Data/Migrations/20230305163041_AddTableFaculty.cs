using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddTableFaculty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscussionTime",
                table: "Idea");

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "Idea",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstClosingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastClosingDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Idea_FacultyId",
                table: "Idea",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Idea_Faculty_FacultyId",
                table: "Idea",
                column: "FacultyId",
                principalTable: "Faculty",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Idea_Faculty_FacultyId",
                table: "Idea");

            migrationBuilder.DropTable(
                name: "Faculty");

            migrationBuilder.DropIndex(
                name: "IX_Idea_FacultyId",
                table: "Idea");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Idea");

            migrationBuilder.AddColumn<DateTime>(
                name: "DiscussionTime",
                table: "Idea",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
