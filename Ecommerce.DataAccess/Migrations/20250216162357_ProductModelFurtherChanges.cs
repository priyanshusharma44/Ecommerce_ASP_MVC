using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ProductModelFurtherChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companys",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "Street", "StreetAddress" },
                values: new object[,]
                {
                    { 4, "Lalitpur", "NextGen Technologies", "9801122334", "44700", "Machine Learning St", "101 AI Boulevard" },
                    { 5, "Bhaktapur", "Cloud Solutions", "9822233445", "44800", "Virtual Way", "202 Cloud Drive" },
                    { 6, "Chitwan", "Digital Horizons", "9845566778", "44200", "Web Innovation Road", "303 Cyber Street" },
                    { 7, "Dharan", "IT Hub Nepal", "9867788990", "56700", "Tech Park Lane", "404 Silicon Valley" },
                    { 8, "Hetauda", "ByteCode Solutions", "9811122334", "44107", "Programming Street", "505 Software Avenue" },
                    { 9, "Butwal", "AI Revolution", "9854455667", "44500", "Deep Learning Lane", "606 Neural Street" },
                    { 10, "Damak", "Quantum Computing Ltd.", "9843344556", "57300", "AI Research Ave", "707 Quantum Road" },
                    { 11, "Janakpur", "Innovate Nepal", "9862233445", "45600", "Startup Avenue", "808 Future Street" },
                    { 12, "Birgunj", "Cyber Security Experts", "9813344556", "44300", "Encryption Lane", "909 Firewall Road" },
                    { 13, "Nepalgunj", "E-Commerce Nepal", "9846677889", "44610", "Online Store Avenue", "1010 Shopping Plaza" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companys",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companys",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Companys",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Companys",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Companys",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Companys",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Companys",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Companys",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Companys",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Companys",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
