using Microsoft.EntityFrameworkCore.Migrations;

namespace projetofinal.Migrations
{
    public partial class ecommerce003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ativo",
                table: "Banner",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Banner");
        }
    }
}
