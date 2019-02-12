using Microsoft.EntityFrameworkCore.Migrations;

namespace GttApiWeb.Migrations
{
    public partial class chagesincerts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fichero64",
                table: "Certificates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fichero64",
                table: "Certificates");
        }
    }
}
