using Microsoft.EntityFrameworkCore.Migrations;

namespace alkoholspiele.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "number",
                table: "Jokes",
                newName: "Number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Jokes",
                newName: "number");
        }
    }
}
