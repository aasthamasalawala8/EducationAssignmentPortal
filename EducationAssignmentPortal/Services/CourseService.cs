using EducationAssignmentPortal.Data;
using EducationAssignmentPortal.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EducationAssignmentPortal.Services
{
    public class CourseService
    {
        private readonly AppDBContext _context;

        public CourseService(AppDBContext context)
        {
            _context = context;
        }

        // ✅ Add Course
        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        // ✅ Get Courses By Faculty
        public List<Course> GetCoursesByFaculty(int facultyId)
        {
            return _context.Courses
                .Where(c => c.FacultyId == facultyId)
                .ToList();
        }

        // ✅ Delete Course
        public void DeleteCourse(int id)
        {
            var course = _context.Courses
                .FirstOrDefault(c => c.Id == id);

            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }
    }
}