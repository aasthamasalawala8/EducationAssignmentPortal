using Microsoft.EntityFrameworkCore;
using EducationAssignmentPortal.Models;
using EducationAssignmentPortal.Data;

namespace EducationAssignmentPortal.Services
{
    public class NotificationService
    {
        private readonly IDbContextFactory<AppDBContext> _factory;

        public NotificationService(IDbContextFactory<AppDBContext> factory)
        {
            _factory = factory;
        }

        public async Task<List<Notification>> GetUserNotifications(string email)
        {
            using var context = _factory.CreateDbContext();

            return await context.Notifications
                .Where(n => n.IsGlobal || n.UserEmail == email)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }

        public async Task<int> GetUnreadCount(string email)
        {
            using var context = _factory.CreateDbContext();

            return await context.Notifications
                .CountAsync(n => !n.IsRead && (n.IsGlobal || n.UserEmail == email));
        }

        public async Task MarkAsRead(int id)
        {
            using var context = _factory.CreateDbContext();

            var notification = await context.Notifications.FindAsync(id);

            if (notification != null)
            {
                notification.IsRead = true;
                await context.SaveChangesAsync();
            }
        }

        // 🔔 NEW - Create Notification
        public async Task CreateNotification(string message, string? userEmail = null, bool isGlobal = false)
        {
            using var context = _factory.CreateDbContext();

            var notification = new Notification
            {
                Message = message,
                UserEmail = userEmail,
                IsGlobal = isGlobal,
                IsRead = false,
                CreatedAt = DateTime.Now
            };

            context.Notifications.Add(notification);
            await context.SaveChangesAsync();
        }
    }
}