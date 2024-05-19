using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication6.Migrations
{
    public partial class cascadebook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Haircut_HaircutIdforBook",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "HaircutId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_HaircutId",
                table: "Book",
                column: "HaircutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Haircut_HaircutId",
                table: "Book",
                column: "HaircutId",
                principalTable: "Haircut",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Haircut_HaircutIdforBook",
                table: "Book",
                column: "HaircutIdforBook",
                principalTable: "Haircut",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Haircut_HaircutId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Haircut_HaircutIdforBook",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_HaircutId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "HaircutId",
                table: "Book");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Haircut_HaircutIdforBook",
                table: "Book",
                column: "HaircutIdforBook",
                principalTable: "Haircut",
                principalColumn: "Id");
        }
    }
}
