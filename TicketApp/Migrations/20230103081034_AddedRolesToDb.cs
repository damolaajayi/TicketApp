using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedRolesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "65d94e21-bb5b-4f88-aa74-6541ae591c1f", "0d689039-d93e-4b2a-8d87-002c49fd6d51", "Manager", "MANAGER" },
                    { "6eab0ad0-5b6f-4358-9b7b-6f719d61d4d4", "21d6e317-aeb6-446f-b822-915f4741d884", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65d94e21-bb5b-4f88-aa74-6541ae591c1f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6eab0ad0-5b6f-4358-9b7b-6f719d61d4d4");
        }
    }
}
