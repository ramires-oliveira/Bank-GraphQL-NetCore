using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankGraphQL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCreate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataModification = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataDelete = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Number = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataCreate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataModification = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataDelete = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Active", "DataCreate", "DataDelete", "DataModification", "Email", "Name" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), true, new DateTime(2023, 7, 16, 23, 58, 2, 460, DateTimeKind.Local).AddTicks(6515), null, null, "user@user.com", "User" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Active", "DataCreate", "DataDelete", "DataModification", "Number", "UserId", "Value" },
                values: new object[] { new Guid("11111111-1111-1111-0000-000000000001"), true, new DateTime(2023, 7, 16, 23, 58, 2, 460, DateTimeKind.Local).AddTicks(6743), null, null, "54321", new Guid("11111111-1111-1111-1111-111111111111"), 1000.00m });

            migrationBuilder.CreateIndex(
                name: "IX_Account_UserId",
                table: "Account",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
