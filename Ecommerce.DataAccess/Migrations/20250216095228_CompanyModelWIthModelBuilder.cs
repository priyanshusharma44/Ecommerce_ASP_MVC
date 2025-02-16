using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CompanyModelWIthModelBuilder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companys",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "Street", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "Kathmandu", "Tech Innovators", "9841234567", "44600", "Tech Lane", "123 Tech Street" },
                    { 2, "Pokhara", "Smart Solutions", "9856789102", "33700", "Innovation Road", "456 IT Park" },
                    { 3, "Biratnagar", "Future Enterprises", "9812345678", "56600", "Enterprise Road", "789 Business Avenue" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companys",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companys",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companys",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
