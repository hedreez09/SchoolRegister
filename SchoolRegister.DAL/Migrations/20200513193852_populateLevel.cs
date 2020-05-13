using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolRegister.DAL.Migrations
{
    public partial class populateLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO StudentClasses (StudentClassId, Level) VALUES (1, 'Basic_1')");
            migrationBuilder.Sql("INSERT INTO StudentClasses (StudentClassId, Level) VALUES (2, 'Basic_2')");
            migrationBuilder.Sql("INSERT INTO StudentClasses (StudentClassId, Level) VALUES (3, 'Basic_3')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
