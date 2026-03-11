using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationAssignmentPortal.Models
{
    public class Student
    {
        public int Id { get; set; } // Primary key

        [Required(ErrorMessage = "Name is required")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 15 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter valid email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Password must be between 4 and 8 characters")]
        public string Password { get; set; } = string.Empty;

        [NotMapped]
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = string.Empty;

    
        [Required(ErrorMessage = "Role is Required")]
        public string Role { get; set; } = string.Empty;

    }
}
