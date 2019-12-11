using Microsoft.EntityFrameworkCore.Migrations;

namespace projetofinal.Migrations
{
    public partial class ecommerce004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Thumb",
                table: "Banner",
                newName: "Imagem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Imagem",
                table: "Banner",
                newName: "Thumb");
        }
    }
}
