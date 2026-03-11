using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationAssignmentPortal.Models
{
    public class Assignment
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public DateTime? DueDate { get; set; }


        public string Status { get; set; } = "Pending";

        public string FacultyEmail { get; set; } = string.Empty;

        // 🔥 NEW: Foreign Key
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        // 🔥 Navigation Property
        public Course? Course { get; set; }

        //public string? Course { get; set; }

        // Foreign Key to Student
        //public int StudentId { get; set; }
        //public Student? Student { get; set; }


    }
}
