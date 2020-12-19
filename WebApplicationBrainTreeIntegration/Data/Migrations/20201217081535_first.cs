using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationBrainTreeIntegration.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    AutherName = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
