using Microsoft.EntityFrameworkCore.Migrations;

namespace EBookStore.Persistence.Migrations
{
    public partial class ColumnAdjustment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedBook_Books_BookId",
                schema: "bs",
                table: "PurchasedBook");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedBook_Users_UserId",
                schema: "bs",
                table: "PurchasedBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasedBook",
                schema: "bs",
                table: "PurchasedBook");

            migrationBuilder.DropColumn(
                name: "Stock",
                schema: "bs",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "bs",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Count",
                schema: "bs",
                table: "PurchasedBook");

            migrationBuilder.RenameTable(
                name: "PurchasedBook",
                schema: "bs",
                newName: "PurchasedBooks",
                newSchema: "bs");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedBook_UserId",
                schema: "bs",
                table: "PurchasedBooks",
                newName: "IX_PurchasedBooks_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedBook_BookId",
                schema: "bs",
                table: "PurchasedBooks",
                newName: "IX_PurchasedBooks_BookId");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorName",
                schema: "bs",
                table: "Books",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "bs",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WrittenIn",
                schema: "bs",
                table: "Books",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasedBooks",
                schema: "bs",
                table: "PurchasedBooks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedBooks_Books_BookId",
                schema: "bs",
                table: "PurchasedBooks",
                column: "BookId",
                principalSchema: "bs",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedBooks_Users_UserId",
                schema: "bs",
                table: "PurchasedBooks",
                column: "UserId",
                principalSchema: "bs",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedBooks_Books_BookId",
                schema: "bs",
                table: "PurchasedBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedBooks_Users_UserId",
                schema: "bs",
                table: "PurchasedBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasedBooks",
                schema: "bs",
                table: "PurchasedBooks");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "bs",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "WrittenIn",
                schema: "bs",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "PurchasedBooks",
                schema: "bs",
                newName: "PurchasedBook",
                newSchema: "bs");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedBooks_UserId",
                schema: "bs",
                table: "PurchasedBook",
                newName: "IX_PurchasedBook_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchasedBooks_BookId",
                schema: "bs",
                table: "PurchasedBook",
                newName: "IX_PurchasedBook_BookId");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorName",
                schema: "bs",
                table: "Books",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                schema: "bs",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "bs",
                table: "Books",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                schema: "bs",
                table: "PurchasedBook",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasedBook",
                schema: "bs",
                table: "PurchasedBook",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedBook_Books_BookId",
                schema: "bs",
                table: "PurchasedBook",
                column: "BookId",
                principalSchema: "bs",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedBook_Users_UserId",
                schema: "bs",
                table: "PurchasedBook",
                column: "UserId",
                principalSchema: "bs",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
