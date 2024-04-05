using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftUniBazar.Data.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdBuyers_Ads_AdId1",
                table: "AdBuyers");

            migrationBuilder.DropIndex(
                name: "IX_AdBuyers_AdId1",
                table: "AdBuyers");

            migrationBuilder.DropColumn(
                name: "AdId1",
                table: "AdBuyers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdId1",
                table: "AdBuyers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdBuyers_AdId1",
                table: "AdBuyers",
                column: "AdId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AdBuyers_Ads_AdId1",
                table: "AdBuyers",
                column: "AdId1",
                principalTable: "Ads",
                principalColumn: "Id");
        }
    }
}
