using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationAssignmentPortal.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCourseRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Courses_FacultyId",
                table: "Courses",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_FacultyId",
                table: "Courses",
                column: "FacultyId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_FacultyId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_FacultyId",
                table: "Courses");
        }
    }
}
