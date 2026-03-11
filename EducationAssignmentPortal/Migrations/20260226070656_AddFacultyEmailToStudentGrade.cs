using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationAssignmentPortal.Migrations
{
    /// <inheritdoc />
    public partial class AddFacultyEmailToStudentGrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FacultyEmail",
                table: "StudentGrades",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacultyEmail",
                table: "StudentGrades");
        }
    }
}
