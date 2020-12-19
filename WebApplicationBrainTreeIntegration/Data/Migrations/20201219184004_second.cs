using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationBrainTreeIntegration.Data.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AutherName", "Name", "Price" },
                values: new object[] { 1, "ALI", "C#", 1000.0 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AutherName", "Name", "Price" },
                values: new object[] { 2, "Mohamed", "Flutter", 2000.0 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AutherName", "Name", "Price" },
                values: new object[] { 3, "Khaled", "Python", 3000.0 });
        }
    }
}
