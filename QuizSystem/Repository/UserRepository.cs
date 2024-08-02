using QuizSystem.Data;
using QuizSystem.Models;

namespace QuizSystem.Repository
{
    public class UserRepository(AppDbContext _context) : IUserRepository
    {
        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public User? GetUser(string username, string password)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == username);
            if (user is null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return null;
            }
            return user;
        }

        public bool UserExists(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
