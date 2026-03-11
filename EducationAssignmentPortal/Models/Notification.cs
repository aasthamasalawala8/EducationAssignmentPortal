using System;
using System.ComponentModel.DataAnnotations;

namespace EducationAssignmentPortal.Models
{
    public class Notification
    {
        public int Id { get; set; }

        [Required]
        public string Message { get; set; } = string.Empty;

        // Who will receive this notification
        public string? UserEmail { get; set; }

        // If null → show to ALL users (Global Notification)
        public bool IsGlobal { get; set; } = false;

        public bool IsRead { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}