using Microsoft.EntityFrameworkCore.Migrations;

namespace GttApiWeb.Migrations
{
    public partial class comprobechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "Jira",
                newName: "url");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "role",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "component",
                table: "Jira",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pass",
                table: "Jira",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "proyect",
                table: "Jira",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "user_idid",
                table: "Jira",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jira_user_idid",
                table: "Jira",
                column: "user_idid");

            migrationBuilder.AddForeignKey(
                name: "FK_Jira_Users_user_idid",
                table: "Jira",
                column: "user_idid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jira_Users_user_idid",
                table: "Jira");

            migrationBuilder.DropIndex(
                name: "IX_Jira_user_idid",
                table: "Jira");

            migrationBuilder.DropColumn(
                name: "email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "component",
                table: "Jira");

            migrationBuilder.DropColumn(
                name: "pass",
                table: "Jira");

            migrationBuilder.DropColumn(
                name: "proyect",
                table: "Jira");

            migrationBuilder.DropColumn(
                name: "user_idid",
                table: "Jira");

            migrationBuilder.RenameColumn(
                name: "url",
                table: "Jira",
                newName: "password");
        }
    }
}
