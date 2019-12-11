using Microsoft.EntityFrameworkCore.Migrations;

namespace projetofinal.Migrations
{
    public partial class ecommercesenac01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Imagem",
                table: "Banner",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Imagem",
                table: "Banner",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
