using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAnimalPassport.Migrations
{
    /// <inheritdoc />
    public partial class ValidationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Valid",
                table: "Vaccinations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Doze",
                table: "Treatments",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BatchNumber",
                table: "Treatments",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Valid",
                table: "Treatments",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valid",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "BatchNumber",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "Valid",
                table: "Treatments");

            migrationBuilder.AlterColumn<double>(
                name: "Doze",
                table: "Treatments",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
