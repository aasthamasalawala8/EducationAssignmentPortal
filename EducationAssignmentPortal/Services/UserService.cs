using EducationAssignmentPortal.Data;
using EducationAssignmentPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace EducationAssignmentPortal.Services
{
    public class UserService
    {
        private readonly AppDBContext _context;

        // Stores currently logged-in user
        public User? LoggedInUser { get; private set; }

        public UserService(AppDBContext context)
        {
            _context = context;
        }

        // ✅ REGISTER USER
        public async Task Register(User user)
        {
            var passwordHasher = new PasswordHasher<User>();

            user.Password = passwordHasher.HashPassword(user, user.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        // ✅ LOGIN USER
        public async Task<User?> ValidateUser(string? email, string? password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return null;

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());

            if (user == null)
                return null;

            var passwordHasher = new PasswordHasher<User>();

            var result = passwordHasher.VerifyHashedPassword(
                user,
                user.Password,
                password
            );

            if (result == PasswordVerificationResult.Success)
            {
                LoggedInUser = user;   // ⭐ IMPORTANT: store logged-in user
                return user;
            }

            return null;
        }

        // ✅ LOGOUT
        public void Logout()
        {
            LoggedInUser = null;
        }

        // ✅ GET CURRENT USER
        public User? GetCurrentUser()
        {
            return LoggedInUser;
        }

        // ✅ GET ALL USERS
        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // ✅ APPROVE FACULTY
        public async Task ApproveFaculty(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user != null)
            {
                user.IsApproved = true;
                await _context.SaveChangesAsync();
            }
        }

        // ✅ DELETE USER
        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        // ✅ ADD NOTIFICATION
        public async Task AddNotification(string message, string? userEmail = null, bool isGlobal = false)
        {
            var notification = new Notification
            {
                Message = message,
                UserEmail = userEmail,
                IsGlobal = isGlobal,
                CreatedAt = DateTime.Now
            };

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
        }
    }
}
//using EducationAssignmentPortal.Data;
//using EducationAssignmentPortal.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity;

//namespace EducationAssignmentPortal.Services
//{
//    public class UserService
//    {
//        private readonly AppDBContext _context;

//        public User? LoggedInUser { get; private set; }
//        //private string? _currentUserEmail;

//        public UserService(AppDBContext context)
//        {
//            _context = context;
//        }

//        // ✅ REGISTER
//        public async Task Register(User user)
//        {
//            var passwordHasher = new PasswordHasher<User>();

//            user.Password = passwordHasher.HashPassword(user, user.Password);

//            _context.Users.Add(user);
//            await _context.SaveChangesAsync();
//        }

//        // ✅ LOGIN
//        public async Task<User?> ValidateUser(string? email, string? password)
//        {
//            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
//                return null;

//            var user = await _context.Users
//                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());

//            if (user == null)
//                return null;

//            var passwordHasher = new PasswordHasher<User>();

//            var result = passwordHasher.VerifyHashedPassword(
//                user,
//                user.Password,
//                password
//            );

//            if (result == PasswordVerificationResult.Success)
//            {
//                LoggedInUser = user;
//                return user;
//            }

//            return null;
//        }

//        public List<User> GetAllUsers()
//        {
//            return _context.Users.ToList();
//        }

//        public void ApproveFaculty(int id)
//        {
//            var user = _context.Users.FirstOrDefault(u => u.Id == id);
//            if (user != null)
//            {
//                user.IsApproved = true;
//                _context.SaveChanges();
//            }
//        }

//        public void DeleteUser(int id)
//        {
//            var user = _context.Users.FirstOrDefault(u => u.Id == id);
//            if (user != null)
//            {
//                _context.Users.Remove(user);
//                _context.SaveChanges();
//            }
//        }

//        // ✅ Get Current Logged-in User
//        public User? GetCurrentUser()
//        {
//            return LoggedInUser;
//        }

//        public void AddNotification(string message, string? userEmail = null, bool isGlobal = false)
//        {
//            var notification = new Notification
//            {
//                Message = message,
//                UserEmail = userEmail,
//                IsGlobal = isGlobal,
//                CreatedAt = DateTime.Now
//            };

//            _context.Notifications.Add(notification);
//            _context.SaveChanges();
//        }
//        //public string GetCurrentUserEmail()
//        //{
//        //    return _currentUserEmail ?? string.Empty;
//        //}

//        //public void SetCurrentUserEmail(string email)
//        //{
//        //    _currentUserEmail = email;
//        //}




//    }
//}


