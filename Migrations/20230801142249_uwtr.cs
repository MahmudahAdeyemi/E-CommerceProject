using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_2.Migrations
{
    public partial class uwtr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea6b2a03-5f09-4f03-8789-f823c17f59d3", "e018c08e-7285-4da2-81b2-91cf984bd81d", "CUSTOMER", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f0d82f26-8bec-4dce-bc02-d197c90f8133", "50ead709-7994-40a1-a330-6d597f28cd6d", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea6b2a03-5f09-4f03-8789-f823c17f59d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0d82f26-8bec-4dce-bc02-d197c90f8133");
        }
    }
}
