using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserBook_AspNetUsers_CollectorId",
                table: "IdentityUserBook");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserBook_Books_BookId",
                table: "IdentityUserBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserBook",
                table: "IdentityUserBook");

            migrationBuilder.RenameTable(
                name: "IdentityUserBook",
                newName: "IdentityUserBooks");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUserBook_CollectorId",
                table: "IdentityUserBooks",
                newName: "IX_IdentityUserBooks_CollectorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserBooks",
                table: "IdentityUserBooks",
                columns: new[] { "BookId", "CollectorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserBooks_AspNetUsers_CollectorId",
                table: "IdentityUserBooks",
                column: "CollectorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserBooks_Books_BookId",
                table: "IdentityUserBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserBooks_AspNetUsers_CollectorId",
                table: "IdentityUserBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserBooks_Books_BookId",
                table: "IdentityUserBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserBooks",
                table: "IdentityUserBooks");

            migrationBuilder.RenameTable(
                name: "IdentityUserBooks",
                newName: "IdentityUserBook");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUserBooks_CollectorId",
                table: "IdentityUserBook",
                newName: "IX_IdentityUserBook_CollectorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserBook",
                table: "IdentityUserBook",
                columns: new[] { "BookId", "CollectorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserBook_AspNetUsers_CollectorId",
                table: "IdentityUserBook",
                column: "CollectorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserBook_Books_BookId",
                table: "IdentityUserBook",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
