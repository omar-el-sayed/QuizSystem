using QuizSystem.Models;

namespace QuizSystem.Repository
{
    public interface IUserRepository
    {
        User? GetUser(string username, string password);
        void AddUser(User user);
        bool UserExists(string username);
        void SaveChanges();
    }
}
