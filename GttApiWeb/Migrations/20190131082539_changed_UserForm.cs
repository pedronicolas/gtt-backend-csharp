using Microsoft.EntityFrameworkCore.Migrations;

namespace GttApiWeb.Migrations
{
    public partial class changed_UserForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jira_Users_user_idid",
                table: "Jira");

            migrationBuilder.DropIndex(
                name: "IX_Jira_user_idid",
                table: "Jira");

            migrationBuilder.DropColumn(
                name: "user_idid",
                table: "Jira");

            migrationBuilder.AddColumn<long>(
                name: "user_id",
                table: "Jira",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Jira");

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
    }
}
