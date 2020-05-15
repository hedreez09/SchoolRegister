using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolRegister.DAL.Migrations
{
    public partial class UpdateOnTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Teacher",
                table: "StudentClasses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePresent",
                table: "Register",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "StudentClasses",
                keyColumn: "StudentClassId",
                keyValue: (byte)1,
                column: "Teacher",
                value: 1);

            migrationBuilder.UpdateData(
                table: "StudentClasses",
                keyColumn: "StudentClassId",
                keyValue: (byte)2,
                column: "Teacher",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StudentClasses",
                keyColumn: "StudentClassId",
                keyValue: (byte)3,
                column: "Teacher",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastName",
                value: "Krish");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfBirth", "LastName", "Sport" },
                values: new object[] { new DateTimeOffset(new DateTime(2011, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Fish", "Gymnastic" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateOfBirth", "LastName" },
                values: new object[] { new DateTimeOffset(new DateTime(2016, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Salman" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateOfBirth", "Sport" },
                values: new object[] { new DateTimeOffset(new DateTime(2013, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Tennis" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                column: "Sport",
                value: "Gymnastic");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                column: "Sport",
                value: "Tenni");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Teacher",
                table: "StudentClasses");

            migrationBuilder.DropColumn(
                name: "DatePresent",
                table: "Register");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastName",
                value: "Griffin Beak Eldritch");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfBirth", "LastName", "Sport" },
                values: new object[] { new DateTimeOffset(new DateTime(1650, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Eldritch", "Football" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateOfBirth", "LastName" },
                values: new object[] { new DateTimeOffset(new DateTime(1650, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Griffin" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateOfBirth", "Sport" },
                values: new object[] { new DateTimeOffset(new DateTime(1650, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Football" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                column: "Sport",
                value: "Football");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                column: "Sport",
                value: "Football");
        }
    }
}
