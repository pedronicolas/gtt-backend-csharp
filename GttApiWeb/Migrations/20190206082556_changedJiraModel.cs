using Microsoft.EntityFrameworkCore.Migrations;

namespace GttApiWeb.Migrations
{
    public partial class changedJiraModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Jira",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "issue_type",
                table: "Jira",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "Jira");

            migrationBuilder.DropColumn(
                name: "issue_type",
                table: "Jira");
        }
    }
}
