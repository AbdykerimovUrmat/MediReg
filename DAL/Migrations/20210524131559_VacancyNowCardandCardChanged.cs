using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class VacancyNowCardandCardChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkTimeInMinutes",
                table: "Vacancies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AboutMe",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkTimeInMinutes",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "AboutMe",
                table: "AspNetUsers");
        }
    }
}
