using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationAssignmentPortal.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentEmailToGrades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentEmail",
                table: "StudentGrades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentEmail",
                table: "StudentGrades");
        }
    }
}
