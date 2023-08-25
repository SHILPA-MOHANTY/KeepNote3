using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeepNote3.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    categoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryCreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    categoryCreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.categoryId);
                    table.ForeignKey(
                        name: "FK_Categories_Users_categoryCreatedBy",
                        column: x => x.categoryCreatedBy,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reminders",
                columns: table => new
                {
                    reminderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reminderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reminderDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    remindrType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReminderCreatedBy = table.Column<int>(type: "int", nullable: false),
                    ReminderCreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminders", x => x.reminderId);
                    table.ForeignKey(
                        name: "FK_Reminders_Users_ReminderCreatedBy",
                        column: x => x.ReminderCreatedBy,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    noteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    categoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.noteId);
                    table.ForeignKey(
                        name: "FK_Notes_Categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Categories",
                        principalColumn: "categoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_categoryCreatedBy",
                table: "Categories",
                column: "categoryCreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_categoryId",
                table: "Notes",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_ReminderCreatedBy",
                table: "Reminders",
                column: "ReminderCreatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Reminders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
