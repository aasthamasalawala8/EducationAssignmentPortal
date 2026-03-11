using System.ComponentModel.DataAnnotations;

namespace EducationAssignmentPortal.Models
{
    public class StudentGrade
    {
        public int Id { get; set; }


        [Required]
        public string StudentEmail { get; set; } = string.Empty;

        [Required]
        public string CourseName { get; set; } = string.Empty;

        [Required]
        [Range(0, 100, ErrorMessage = "Marks must be between 0 and 100")]
        public int Marks { get; set; }

       
        public string Grade { get; set; }

        public string? FacultyEmail { get; set; }
    }
}
