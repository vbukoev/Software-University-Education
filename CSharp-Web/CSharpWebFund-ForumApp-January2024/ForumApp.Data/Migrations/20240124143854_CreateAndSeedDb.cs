using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Forum.App.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateAndSeedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[,]
                {
                    { new Guid("63277475-01c3-4dc1-84da-5a51ebac7de9"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer lacinia nibh a risus hendrerit tincidunt. Donec porta nulla arcu, at.", "My Third Post" },
                    { new Guid("cfdcbea5-1be9-4cb6-8e18-2d3a14d467cb"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed eu lacinia turpis. Quisque eu dapibus sem. Mauris pharetra ultrices leo.", "My Second Post" },
                    { new Guid("d6d99310-8a2c-42ab-8cf5-a07ce17c232b"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ullamcorper, risus quis fermentum lacinia, dui nisi posuere nisl, eget dictum.", "My First Post" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
