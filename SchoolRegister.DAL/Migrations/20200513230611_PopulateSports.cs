using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolRegister.DAL.Migrations
{
    public partial class PopulateSports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Sports (SportId, SportName) VALUES (1, 'Football')");
            migrationBuilder.Sql("INSERT INTO Sports (SportId, SportName) VALUES (2, 'Tennis')");
            migrationBuilder.Sql("INSERT INTO Sports (SportId, SportName) VALUES (3, 'BoardGame')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
