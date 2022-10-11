using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MercatorWebshop.Data.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prodavnica",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodavnica", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Artikl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cijena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    ProdavnicaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Artikl_Prodavnica_ProdavnicaID",
                        column: x => x.ProdavnicaID,
                        principalTable: "Prodavnica",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artikl_ProdavnicaID",
                table: "Artikl",
                column: "ProdavnicaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artikl");

            migrationBuilder.DropTable(
            name: "Prodavnica");
        }

        
    }
}
