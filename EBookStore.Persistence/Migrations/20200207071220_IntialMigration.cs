using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EBookStore.Persistence.Migrations
{
    public partial class IntialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "bs");

            migrationBuilder.CreateSequence(
                name: "auto_increment",
                schema: "bs");

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "bs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValueSql: "nextval('bs.auto_increment')"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    AuthorName = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    PublishedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "(now() at time zone 'utc')"),
                    Cost = table.Column<decimal>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "bs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValueSql: "nextval('bs.auto_increment')"),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchasedBook",
                schema: "bs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValueSql: "nextval('bs.auto_increment')"),
                    UserId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    PurchasedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "(now() at time zone 'utc')"),
                    Count = table.Column<int>(nullable: false),
                    PaymentMode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasedBook_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "bs",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasedBook_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "bs",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedBook_BookId",
                schema: "bs",
                table: "PurchasedBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedBook_UserId",
                schema: "bs",
                table: "PurchasedBook",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "bs",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchasedBook",
                schema: "bs");

            migrationBuilder.DropTable(
                name: "Books",
                schema: "bs");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "bs");

            migrationBuilder.DropSequence(
                name: "auto_increment",
                schema: "bs");
        }
    }
}
