using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class FixTableIdea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HashTag",
                table: "Idea",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Faculty", "FullName", "Password", "PhoneNumber", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "tonydo0307@gmail.com", "IT", "Staff", "123456", 11112222, 0, "Staff" },
                    { 2, "tonydo0307@gmail.com", "IT", "Admin", "123456", 11112222, 1, "Admin" },
                    { 3, "tonydo0307@gmail.com", "IT", "QAManager", "123456", 11112222, 2, "QAManager" },
                    { 4, "tonydo0307@gmail.com", "IT", "QACoordinator", "123456", 11112222, 3, "QACoordinator" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "HashTag",
                table: "Idea");
        }
    }
}
