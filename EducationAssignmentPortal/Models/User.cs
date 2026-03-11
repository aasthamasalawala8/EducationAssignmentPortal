using System.ComponentModel.DataAnnotations;

namespace EducationAssignmentPortal.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        public string Role { get; set; } = "Student"; // Admin , Student ,faculty

        // Optional: For Faculty Approval System
        public bool IsApproved { get; set; } = true;
    }
}
