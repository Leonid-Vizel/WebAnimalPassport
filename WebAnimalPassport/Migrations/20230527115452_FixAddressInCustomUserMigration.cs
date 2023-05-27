using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAnimalPassport.Migrations
{
    /// <inheritdoc />
    public partial class FixAddressInCustomUserMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adres",
                table: "AspNetUsers",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "AspNetUsers",
                newName: "Adres");
        }
    }
}
