using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddDefaultValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryDescription", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Back-end", "Python" },
                    { 2, "Back-end", "ASP .Net Core" },
                    { 3, "Front-end", "Angular" },
                    { 4, "Front-end", "ReactJS" }
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "Id", "EventDescription", "EventName", "FirstClosingDate", "LastClosingDate", "UserId" },
                values: new object[] { 1, "Software engineer", "IT talk show", new DateTime(2023, 4, 8, 0, 33, 58, 880, DateTimeKind.Local).AddTicks(4840), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), 4 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Department",
                value: 1);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                column: "Department",
                value: 1);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Department", "DoB", "Email", "FullName", "Password", "PhoneNumber", "Role", "UserName" },
                values: new object[,]
                {
                    { 5, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tonydo0307@gmail.com", "QACoordinator1", "123456", 11112222, 3, "QACoordinator1" },
                    { 6, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tonydo0307@gmail.com", "Staff1", "123456", 11112222, 0, "Staff1" }
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "Id", "EventDescription", "EventName", "FirstClosingDate", "LastClosingDate", "UserId" },
                values: new object[] { 2, "Block Chain", "Business talk show", new DateTime(2023, 4, 8, 0, 33, 58, 880, DateTimeKind.Local).AddTicks(4848), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), 5 });

            migrationBuilder.InsertData(
                table: "Idea",
                columns: new[] { "Id", "DateSubmitted", "EventId", "File", "HashTag", "IdeaDescription", "IdeaTitle", "UserId" },
                values: new object[] { 1, new DateTime(2023, 4, 8, 0, 33, 58, 880, DateTimeKind.Local).AddTicks(4858), 1, "Demo.docx", "#IT", "What do you need to be a software engineer?", "Question", 1 });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "CommentContent", "DateSubmitted", "IdeaId", "UserId" },
                values: new object[,]
                {
                    { 1, "string", new DateTime(2023, 4, 8, 0, 33, 58, 880, DateTimeKind.Local).AddTicks(5145), 1, 2 },
                    { 2, "string", new DateTime(2023, 4, 8, 0, 33, 58, 880, DateTimeKind.Local).AddTicks(5149), 1, 3 },
                    { 3, "string", new DateTime(2023, 4, 8, 0, 33, 58, 880, DateTimeKind.Local).AddTicks(5150), 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "Idea",
                columns: new[] { "Id", "DateSubmitted", "EventId", "File", "HashTag", "IdeaDescription", "IdeaTitle", "UserId" },
                values: new object[] { 2, new DateTime(2023, 4, 8, 0, 33, 58, 880, DateTimeKind.Local).AddTicks(4859), 2, "Demo.docx", "#Business", "What do you need to be a software engineer?", "Question", 6 });

            migrationBuilder.InsertData(
                table: "IdeaCategories",
                columns: new[] { "CategoriesId", "IdeasId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "IdeaId", "NotificationName" },
                values: new object[] { 1, 1, "string 123" });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "CommentContent", "DateSubmitted", "IdeaId", "UserId" },
                values: new object[,]
                {
                    { 4, "string", new DateTime(2023, 4, 8, 0, 33, 58, 880, DateTimeKind.Local).AddTicks(5150), 2, 3 },
                    { 5, "string", new DateTime(2023, 4, 8, 0, 33, 58, 880, DateTimeKind.Local).AddTicks(5151), 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "IdeaCategories",
                columns: new[] { "CategoriesId", "IdeasId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 3, 2 },
                    { 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "Id", "IdeaId", "NotificationName" },
                values: new object[] { 2, 2, "string 1234" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "IdeaCategories",
                keyColumns: new[] { "CategoriesId", "IdeasId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "IdeaCategories",
                keyColumns: new[] { "CategoriesId", "IdeasId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "IdeaCategories",
                keyColumns: new[] { "CategoriesId", "IdeasId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "IdeaCategories",
                keyColumns: new[] { "CategoriesId", "IdeasId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "IdeaCategories",
                keyColumns: new[] { "CategoriesId", "IdeasId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "IdeaCategories",
                keyColumns: new[] { "CategoriesId", "IdeasId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notification",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Idea",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Idea",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Department",
                value: 0);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                column: "Department",
                value: 0);
        }
    }
}
