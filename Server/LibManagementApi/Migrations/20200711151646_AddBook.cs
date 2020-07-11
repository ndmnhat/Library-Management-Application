using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibManagementApi.Migrations
{
    public partial class AddBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<byte[]>(nullable: false),
                    Bookname = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: false),
                    YearofPub = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                });

            migrationBuilder.CreateTable(
                name: "BookBorrowings",
                columns: table => new
                {
                    BookBorrowingID = table.Column<byte[]>(nullable: false),
                    UserID = table.Column<byte[]>(nullable: false),
                    BookID = table.Column<byte[]>(nullable: false),
                    BorrowDate = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrowings", x => x.BookBorrowingID);
                    table.ForeignKey(
                        name: "FK_BookBorrowings_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBorrowings_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookReturnings",
                columns: table => new
                {
                    BookReturningID = table.Column<byte[]>(nullable: false),
                    BookBorrowingID = table.Column<byte[]>(nullable: false),
                    ActualReturnDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookReturnings", x => x.BookReturningID);
                    table.ForeignKey(
                        name: "FK_BookReturnings_BookBorrowings_BookBorrowingID",
                        column: x => x.BookBorrowingID,
                        principalTable: "BookBorrowings",
                        principalColumn: "BookBorrowingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowings_BookID",
                table: "BookBorrowings",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowings_UserID",
                table: "BookBorrowings",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_BookReturnings_BookBorrowingID",
                table: "BookReturnings",
                column: "BookBorrowingID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookReturnings");

            migrationBuilder.DropTable(
                name: "BookBorrowings");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
