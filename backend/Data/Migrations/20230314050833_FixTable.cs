using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class FixTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Idea_Event_FacultyId",
                table: "Idea");

            migrationBuilder.RenameColumn(
                name: "FacultyId",
                table: "Idea",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Idea_FacultyId",
                table: "Idea",
                newName: "IX_Idea_EventId");

            migrationBuilder.RenameColumn(
                name: "FacultyName",
                table: "Event",
                newName: "EventName");

            migrationBuilder.RenameColumn(
                name: "FacultyDescription",
                table: "Event",
                newName: "EventDescription");

            migrationBuilder.AddForeignKey(
                name: "FK_Idea_Event_EventId",
                table: "Idea",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Idea_Event_EventId",
                table: "Idea");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Idea",
                newName: "FacultyId");

            migrationBuilder.RenameIndex(
                name: "IX_Idea_EventId",
                table: "Idea",
                newName: "IX_Idea_FacultyId");

            migrationBuilder.RenameColumn(
                name: "EventName",
                table: "Event",
                newName: "FacultyName");

            migrationBuilder.RenameColumn(
                name: "EventDescription",
                table: "Event",
                newName: "FacultyDescription");

            migrationBuilder.AddForeignKey(
                name: "FK_Idea_Event_FacultyId",
                table: "Idea",
                column: "FacultyId",
                principalTable: "Event",
                principalColumn: "Id");
        }
    }
}
