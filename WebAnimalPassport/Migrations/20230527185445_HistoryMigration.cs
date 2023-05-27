using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAnimalPassport.Migrations
{
    /// <inheritdoc />
    public partial class HistoryMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnerHistory_Animals_AnimalId",
                table: "OwnerHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnerHistory_AspNetUsers_UserId",
                table: "OwnerHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OwnerHistory",
                table: "OwnerHistory");

            migrationBuilder.RenameTable(
                name: "OwnerHistory",
                newName: "History");

            migrationBuilder.RenameIndex(
                name: "IX_OwnerHistory_UserId",
                table: "History",
                newName: "IX_History_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OwnerHistory_AnimalId",
                table: "History",
                newName: "IX_History_AnimalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_History",
                table: "History",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_History_Animals_AnimalId",
                table: "History",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_History_AspNetUsers_UserId",
                table: "History",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_Animals_AnimalId",
                table: "History");

            migrationBuilder.DropForeignKey(
                name: "FK_History_AspNetUsers_UserId",
                table: "History");

            migrationBuilder.DropPrimaryKey(
                name: "PK_History",
                table: "History");

            migrationBuilder.RenameTable(
                name: "History",
                newName: "OwnerHistory");

            migrationBuilder.RenameIndex(
                name: "IX_History_UserId",
                table: "OwnerHistory",
                newName: "IX_OwnerHistory_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_History_AnimalId",
                table: "OwnerHistory",
                newName: "IX_OwnerHistory_AnimalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OwnerHistory",
                table: "OwnerHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerHistory_Animals_AnimalId",
                table: "OwnerHistory",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerHistory_AspNetUsers_UserId",
                table: "OwnerHistory",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
