using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GttApiWeb.Migrations
{
    public partial class jiraComponent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type",
                table: "Certificates",
                newName: "subject");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Certificates",
                newName: "repositorio");

            migrationBuilder.AddColumn<string>(
                name: "alias",
                table: "Certificates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "contraseña",
                table: "Certificates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Certificates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "entidadEmisora",
                table: "Certificates",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCaducidad",
                table: "Certificates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "idOrga",
                table: "Certificates",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "listaIntegraciones",
                table: "Certificates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nombreCliente",
                table: "Certificates",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "numeroSerie",
                table: "Certificates",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "observaciones",
                table: "Certificates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "alias",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "contraseña",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "email",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "entidadEmisora",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "fechaCaducidad",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "idOrga",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "listaIntegraciones",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "nombreCliente",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "numeroSerie",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "observaciones",
                table: "Certificates");

            migrationBuilder.RenameColumn(
                name: "subject",
                table: "Certificates",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "repositorio",
                table: "Certificates",
                newName: "name");
        }
    }
}
