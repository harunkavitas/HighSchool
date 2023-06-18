using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighSchool.Migrations
{
    /// <inheritdoc />
    public partial class AddedTeacherIdToCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "AppCourses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppCourses_TeacherId",
                table: "AppCourses",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCourses_AppTeachers_TeacherId",
                table: "AppCourses",
                column: "TeacherId",
                principalTable: "AppTeachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCourses_AppTeachers_TeacherId",
                table: "AppCourses");

            migrationBuilder.DropIndex(
                name: "IX_AppCourses_TeacherId",
                table: "AppCourses");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "AppCourses");
        }
    }
}
