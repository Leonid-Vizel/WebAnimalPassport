using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebAnimalPassport.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InitialUserId = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    DeathDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PhotoPath = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Breed = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Sex = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Hair = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    ChipNumber = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    ChipDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ChipLocation = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    TattoNumber = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    TattoDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LostLocation = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Surname = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Patronymic = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    City = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Region = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Country = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Address = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Index = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    PhotoPath = table.Column<string>(type: "text", nullable: true),
                    EventId = table.Column<long>(type: "bigint", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    PhotoPath = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    DateStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateFinish = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Examinations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnimalId = table.Column<long>(type: "bigint", nullable: false),
                    DoctorId = table.Column<string>(type: "text", nullable: true),
                    PhotoPath = table.Column<string>(type: "text", nullable: true),
                    Declaration = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DoctorName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Examinations_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Examinations_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    AnimalId = table.Column<long>(type: "bigint", nullable: false),
                    TransmitDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Reason = table.Column<string>(type: "character varying(10000)", maxLength: 10000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.Id);
                    table.ForeignKey(
                        name: "FK_History_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_History_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnimalId = table.Column<long>(type: "bigint", nullable: false),
                    DoctorId = table.Column<string>(type: "text", nullable: true),
                    PhotoPath = table.Column<string>(type: "text", nullable: true),
                    Valid = table.Column<bool>(type: "boolean", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TreatmentType = table.Column<string>(type: "text", nullable: false),
                    Drug = table.Column<string>(type: "character varying(10000)", maxLength: 10000, nullable: true),
                    Doze = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BatchNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DoctorName = table.Column<string>(type: "character varying(10000)", maxLength: 10000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treatments_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Treatments_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vaccinations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnimalId = table.Column<long>(type: "bigint", nullable: false),
                    DoctorId = table.Column<string>(type: "text", nullable: true),
                    PhotoPath = table.Column<string>(type: "text", nullable: true),
                    Valid = table.Column<bool>(type: "boolean", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Series = table.Column<string>(type: "text", nullable: true),
                    DoctorName = table.Column<string>(type: "character varying(10000)", maxLength: 10000, nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaccinations_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vaccinations_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_InitialUserId",
                table: "Animals",
                column: "InitialUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_UserId",
                table: "Animals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EventId",
                table: "AspNetUsers",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserId",
                table: "Events",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_AnimalId",
                table: "Examinations",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_DoctorId",
                table: "Examinations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_History_AnimalId",
                table: "History",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_History_UserId",
                table: "History",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_AnimalId",
                table: "Notes",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_AnimalId",
                table: "Treatments",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_DoctorId",
                table: "Treatments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_AnimalId",
                table: "Vaccinations",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_DoctorId",
                table: "Vaccinations",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_AspNetUsers_InitialUserId",
                table: "Animals",
                column: "InitialUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_AspNetUsers_UserId",
                table: "Animals",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Events_EventId",
                table: "AspNetUsers",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_UserId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Examinations");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropTable(
                name: "Vaccinations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
