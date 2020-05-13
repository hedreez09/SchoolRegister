using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolRegister.DAL.Migrations
{
    public partial class AddSport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Sport_SportId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sport",
                table: "Sport");

            migrationBuilder.RenameTable(
                name: "Sport",
                newName: "Sports");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sports",
                table: "Sports",
                column: "SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Sports_SportId",
                table: "Students",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "SportId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Sports_SportId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sports",
                table: "Sports");

            migrationBuilder.RenameTable(
                name: "Sports",
                newName: "Sport");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sport",
                table: "Sport",
                column: "SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Sport_SportId",
                table: "Students",
                column: "SportId",
                principalTable: "Sport",
                principalColumn: "SportId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
