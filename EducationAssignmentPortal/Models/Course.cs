using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationAssignmentPortal.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select a course")]
        public string? CourseName { get; set; }

        [Required]
        public string? CourseCode{ get; set; }

        [ForeignKey("Faculty")]
        public int? FacultyId { get; set; }
        // Navigation Property
        public User? Faculty { get; set; }

        public List<Assignment>? Assignments { get; set; }
    }
}
