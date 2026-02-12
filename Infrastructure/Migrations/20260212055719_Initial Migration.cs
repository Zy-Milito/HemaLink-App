using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    AccountType = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    AdmissionStatus = table.Column<int>(type: "integer", nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Donator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donator", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AccountType", "Email", "IsActive", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "Staff", "admin", true, "admin", "$2a$11$N7G6W/AvtDo3xJkxWM664eRDmcYulvWvwb.09q5T381GvicCyny4K", 1 },
                    { 2, "Staff", "mod", true, "mod", "$2a$11$wRKnnwjzr/zEwV3uUsSuyu3dQxU0Fkv98ejMi334ncv1r8eeTf6PS", 0 }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AccountType", "AdmissionStatus", "Email", "IsActive", "Name", "Password" },
                values: new object[] { 3, "Requester", 1, "gruppesechs@mail.com", true, "Gruppe Sechs", "$2a$11$zfzhWyeQnBPvmZd3Kir3eeE9HoigS5eqioH5R4Ulmf1soMEGQe3Ym" });

            migrationBuilder.InsertData(
                table: "Donator",
                columns: new[] { "Id", "Email", "Name", "Phone" },
                values: new object[] { 1, "gabriel@mail.com", "Gabriel", "1234567890123" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Donator");
        }
    }
}
