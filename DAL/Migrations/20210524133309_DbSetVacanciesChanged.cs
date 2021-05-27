using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class DbSetVacanciesChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_AspNetUsers_UserId",
                table: "Vacancies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vacancies",
                table: "Vacancies");

            migrationBuilder.RenameTable(
                name: "Vacancies",
                newName: "Cards");

            migrationBuilder.RenameIndex(
                name: "IX_Vacancies_UserId",
                table: "Cards",
                newName: "IX_Cards_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cards",
                table: "Cards",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_AspNetUsers_UserId",
                table: "Cards",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_AspNetUsers_UserId",
                table: "Cards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cards",
                table: "Cards");

            migrationBuilder.RenameTable(
                name: "Cards",
                newName: "Vacancies");

            migrationBuilder.RenameIndex(
                name: "IX_Cards_UserId",
                table: "Vacancies",
                newName: "IX_Vacancies_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vacancies",
                table: "Vacancies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_AspNetUsers_UserId",
                table: "Vacancies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
