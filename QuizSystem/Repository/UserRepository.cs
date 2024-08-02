using QuizSystem.Models;

namespace QuizSystem.Repository
{
    public class UserRepository() : IUserRepository
    {
        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool UserExists(string username)
        {
            throw new NotImplementedException();
        }
    }
}
