using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication6.Migrations
{
    public partial class cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coment_Haircut_HaircutIdforBook",
                table: "Coment");

            migrationBuilder.AddColumn<int>(
                name: "HaircutId",
                table: "Coment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coment_HaircutId",
                table: "Coment",
                column: "HaircutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coment_Haircut_HaircutId",
                table: "Coment",
                column: "HaircutId",
                principalTable: "Haircut",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Coment_Haircut_HaircutIdforBook",
                table: "Coment",
                column: "HaircutIdforBook",
                principalTable: "Haircut",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coment_Haircut_HaircutId",
                table: "Coment");

            migrationBuilder.DropForeignKey(
                name: "FK_Coment_Haircut_HaircutIdforBook",
                table: "Coment");

            migrationBuilder.DropIndex(
                name: "IX_Coment_HaircutId",
                table: "Coment");

            migrationBuilder.DropColumn(
                name: "HaircutId",
                table: "Coment");

            migrationBuilder.AddForeignKey(
                name: "FK_Coment_Haircut_HaircutIdforBook",
                table: "Coment",
                column: "HaircutIdforBook",
                principalTable: "Haircut",
                principalColumn: "Id");
        }
    }
}
