using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Watchlist.Data.Migrations
{
    public partial class newDbSetAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovie_AspNetUsers_UserId",
                table: "UserMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMovie_Movies_MovieId",
                table: "UserMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMovie",
                table: "UserMovie");

            migrationBuilder.RenameTable(
                name: "UserMovie",
                newName: "UsersMovies");

            migrationBuilder.RenameIndex(
                name: "IX_UserMovie_MovieId",
                table: "UsersMovies",
                newName: "IX_UsersMovies_MovieId");

            migrationBuilder.AlterTable(
                name: "Movies",
                comment: "Table Movie");

            migrationBuilder.AlterTable(
                name: "Genres",
                comment: "Table Genre");

            migrationBuilder.AlterTable(
                name: "UsersMovies",
                comment: "Table UserMovies");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Movie Title",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "Movies",
                type: "decimal(18,2)",
                nullable: false,
                comment: "Movie Rating",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Movie Image",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "Movies",
                type: "int",
                nullable: false,
                comment: "Movie Genre Identifier",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Director",
                table: "Movies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Movie Director",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Movies",
                type: "int",
                nullable: false,
                comment: "Movie Identifier",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genres",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Genre Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Genres",
                type: "int",
                nullable: false,
                comment: "Genre Identifier",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "UsersMovies",
                type: "int",
                nullable: false,
                comment: "Movie Identifier",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UsersMovies",
                type: "nvarchar(450)",
                nullable: false,
                comment: "User Identifier",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersMovies",
                table: "UsersMovies",
                columns: new[] { "UserId", "MovieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersMovies_AspNetUsers_UserId",
                table: "UsersMovies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersMovies_Movies_MovieId",
                table: "UsersMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersMovies_AspNetUsers_UserId",
                table: "UsersMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersMovies_Movies_MovieId",
                table: "UsersMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersMovies",
                table: "UsersMovies");

            migrationBuilder.RenameTable(
                name: "UsersMovies",
                newName: "UserMovie");

            migrationBuilder.RenameIndex(
                name: "IX_UsersMovies_MovieId",
                table: "UserMovie",
                newName: "IX_UserMovie_MovieId");

            migrationBuilder.AlterTable(
                name: "Movies",
                oldComment: "Table Movie");

            migrationBuilder.AlterTable(
                name: "Genres",
                oldComment: "Table Genre");

            migrationBuilder.AlterTable(
                name: "UserMovie",
                oldComment: "Table UserMovies");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Movie Title");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "Movies",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComment: "Movie Rating");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Movie Image");

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "Movies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Movie Genre Identifier");

            migrationBuilder.AlterColumn<string>(
                name: "Director",
                table: "Movies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Movie Director");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Movies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Movie Identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genres",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Genre Name");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Genres",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Genre Identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "UserMovie",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Movie Identifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserMovie",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "User Identifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMovie",
                table: "UserMovie",
                columns: new[] { "UserId", "MovieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovie_AspNetUsers_UserId",
                table: "UserMovie",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovie_Movies_MovieId",
                table: "UserMovie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
