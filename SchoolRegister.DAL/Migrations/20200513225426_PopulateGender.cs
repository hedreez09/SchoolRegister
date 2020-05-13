using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolRegister.DAL.Migrations
{
    public partial class PopulateGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genders (GenderId, GenderType) VALUES (1, 'Male')");
            migrationBuilder.Sql("INSERT INTO Genders (GenderId, GenderType) VALUES (2, 'female')");
            migrationBuilder.Sql("INSERT INTO Genders (GenderId, GenderType) VALUES (3, 'Undisclosed')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
