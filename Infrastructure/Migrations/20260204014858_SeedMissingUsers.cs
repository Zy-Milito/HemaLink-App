using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedMissingUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrentStatus",
                table: "User",
                newName: "AdmissionStatus");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$N.nB45mfZ.ocViJjnR4ejubZdpw9qaT3lRUn.rrvboIItU5cZFQ0i");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AdmissionStatus", "Email", "IsActive", "Name", "Password", "Role", "UserType" },
                values: new object[,]
                {
                    { 2, 1, "gruppesechs@mail.com", true, "Gruppe Sechs", "$2a$11$sVDJf6dm5xNO265f9Xjrk.OXPRol.9xTL0gYLtzThgHJ1WepLke7G", 0, "Requester" },
                    { 3, 0, "grupogamma@mail.com", true, "Grupo Gamma", "$2a$11$LewVl0EJZyPaFJ43QlpEQOp8YZyqYrCeUFJU8hYMIQVtp0iW.JBsK", 0, "Requester" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "BloodType", "DonationCount", "Email", "IsActive", "Name", "Password", "Role", "UserType" },
                values: new object[] { 4, null, 0, "gabriel@mail.com", true, "Gabriel", "$2a$11$w6L6TmrpQ5lc221kEmWS0..thYqaSiXi5g4FEajiLPXpgNFTHq5WO", 0, "Donator" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "AdmissionStatus",
                table: "User",
                newName: "CurrentStatus");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$Ri.lDA6iAK6QKoclx4ARNuHY4zNxFyhfikN4c5u2y7jIDN2egViqC");
        }
    }
}
