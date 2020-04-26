using Microsoft.EntityFrameworkCore.Migrations;

namespace TitanGate.Website.DAL.Migrations
{
    public partial class Seed_Categories_And_Login : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[] { 1, "news", null });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[] { 2, "online store", null });

            migrationBuilder.InsertData(
                table: "Login",
                columns: new[] { "Id", "Email", "Password" },
                values: new object[] { 1, "dayanakyuchukova@gmail.com", "1234" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[] { 3, "online jewelry", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Login",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
