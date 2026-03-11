using EducationAssignmentPortal.Models;
using EducationAssignmentPortal.Data;
using Microsoft.EntityFrameworkCore;

namespace EducationAssignmentPortal.Services
{
    public class AssignmentService
    {
        private readonly IDbContextFactory<AppDBContext> _factory;

        public AssignmentService(IDbContextFactory<AppDBContext> factory)
        {
            _factory = factory;
        }

        // 🔹 Get ALL assignments (Admin / Faculty)
        public async Task<List<Assignment>> GetAllAssignments()
        {
            using var context = _factory.CreateDbContext();

            return await context.Assignments
                .Include(a => a.Course)
                .ToListAsync();
        }

        // 🔹 Get assignments by Course
        public async Task<List<Assignment>> GetAssignmentsByCourseAsync(int courseId)
        {
            using var context = _factory.CreateDbContext();

            return await context.Assignments
                .Where(a => a.CourseId == courseId)
                .Include(a => a.Course)
                .ToListAsync();
        }

        // 🔹 Get assignment by Id
        public async Task<Assignment?> GetById(int id)
        {
            using var context = _factory.CreateDbContext();

            return await context.Assignments
                .Include(a => a.Course)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        // 🔹 Add new assignment
        public async Task AddAssignmentAsync(Assignment assignment)
        {
            using var context = _factory.CreateDbContext();

            context.Assignments.Add(assignment);
            await context.SaveChangesAsync();
        }

        // 🔹 Update full assignment
        public async Task UpdateAssignmentAsync(Assignment assignment)
        {
            using var context = _factory.CreateDbContext();

            context.Assignments.Update(assignment);
            await context.SaveChangesAsync();
        }

        // 🔹 Update only status (Student)
        public async Task UpdateStatusAsync(int id, string status)
        {
            using var context = _factory.CreateDbContext();

            var assignment = await context.Assignments
                .FirstOrDefaultAsync(a => a.Id == id);

            if (assignment != null)
            {
                assignment.Status = status;
                await context.SaveChangesAsync();
            }
        }

        // 🔹 Delete assignment
        public async Task DeleteAssignmentAsync(int id)
        {
            using var context = _factory.CreateDbContext();

            var assignment = await context.Assignments
                .FirstOrDefaultAsync(a => a.Id == id);

            if (assignment != null)
            {
                context.Assignments.Remove(assignment);
                await context.SaveChangesAsync();
            }
        }
    }
}