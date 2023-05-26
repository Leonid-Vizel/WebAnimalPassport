using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebAnimalPassport.Migrations
{
    /// <inheritdoc />
    public partial class Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_AspNetUsers_UserId1",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_UserId1",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Animals");

            migrationBuilder.AddColumn<string>(
                name: "DoctorId",
                table: "Vaccinations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorName",
                table: "Vaccinations",
                type: "character varying(10000)",
                maxLength: 10000,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Vaccinations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Series",
                table: "Vaccinations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Vaccinations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Vaccinations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "AnimalId",
                table: "Treatments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "DoctorId",
                table: "Treatments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorName",
                table: "Treatments",
                type: "character varying(10000)",
                maxLength: 10000,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Doze",
                table: "Treatments",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Drug",
                table: "Treatments",
                type: "character varying(10000)",
                maxLength: 10000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TreatmentType",
                table: "Treatments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Animals",
                type: "text",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnimalId = table.Column<long>(type: "bigint", nullable: false),
                    Text = table.Column<string>(type: "character varying(30000)", maxLength: 30000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_DoctorId",
                table: "Vaccinations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_AnimalId",
                table: "Treatments",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_DoctorId",
                table: "Treatments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_UserId",
                table: "Animals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_AnimalId",
                table: "Notes",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_AspNetUsers_UserId",
                table: "Animals",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Animals_AnimalId",
                table: "Treatments",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_AspNetUsers_DoctorId",
                table: "Treatments",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_AspNetUsers_DoctorId",
                table: "Vaccinations",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_AspNetUsers_UserId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Animals_AnimalId",
                table: "Treatments");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_AspNetUsers_DoctorId",
                table: "Treatments");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_AspNetUsers_DoctorId",
                table: "Vaccinations");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Vaccinations_DoctorId",
                table: "Vaccinations");

            migrationBuilder.DropIndex(
                name: "IX_Treatments_AnimalId",
                table: "Treatments");

            migrationBuilder.DropIndex(
                name: "IX_Treatments_DoctorId",
                table: "Treatments");

            migrationBuilder.DropIndex(
                name: "IX_Animals_UserId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "DoctorName",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "Series",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Vaccinations");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "DoctorName",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "Doze",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "Drug",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "TreatmentType",
                table: "Treatments");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Animals",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Animals",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animals_UserId1",
                table: "Animals",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_AspNetUsers_UserId1",
                table: "Animals",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
