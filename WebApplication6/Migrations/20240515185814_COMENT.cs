using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication6.Migrations
{
    public partial class COMENT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HaircutIdforBook = table.Column<int>(type: "int", nullable: true),
                    UserComent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coment_Haircut_HaircutIdforBook",
                        column: x => x.HaircutIdforBook,
                        principalTable: "Haircut",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coment_HaircutIdforBook",
                table: "Coment",
                column: "HaircutIdforBook");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coment");
        }
    }
}
