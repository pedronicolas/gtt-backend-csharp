using Microsoft.EntityFrameworkCore.Migrations;

namespace GttApiWeb.Migrations
{
    public partial class changedCertificates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "contraseña",
                table: "Certificates",
                newName: "password");

            migrationBuilder.AlterColumn<string>(
                name: "numeroSerie",
                table: "Certificates",
                nullable: true,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "Certificates",
                newName: "contraseña");

            migrationBuilder.AlterColumn<long>(
                name: "numeroSerie",
                table: "Certificates",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
