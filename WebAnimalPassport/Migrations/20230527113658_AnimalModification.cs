using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebAnimalPassport.Migrations
{
    /// <inheritdoc />
    public partial class AnimalModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Species",
                table: "Animals");

            migrationBuilder.AddColumn<string>(
                name: "InitialUserId",
                table: "Animals",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Animals",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OwnerHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    AnimalId = table.Column<long>(type: "bigint", nullable: false),
                    TransmitDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Reason = table.Column<string>(type: "character varying(10000)", maxLength: 10000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnerHistory_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnerHistory_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_InitialUserId",
                table: "Animals",
                column: "InitialUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerHistory_AnimalId",
                table: "OwnerHistory",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerHistory_UserId",
                table: "OwnerHistory",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_AspNetUsers_InitialUserId",
                table: "Animals",
                column: "InitialUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_AspNetUsers_InitialUserId",
                table: "Animals");

            migrationBuilder.DropTable(
                name: "OwnerHistory");

            migrationBuilder.DropIndex(
                name: "IX_Animals_InitialUserId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "InitialUserId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Animals");

            migrationBuilder.AddColumn<string>(
                name: "Species",
                table: "Animals",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }
    }
}
