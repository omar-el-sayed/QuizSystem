using QuizSystem.Helpers;
using QuizSystem.Models;
using QuizSystem.Repository;
using QuizSystem.ViewModels.User;

namespace QuizSystem.Services.UserManagement
{
    public class UserService(IUserRepository _repository) : IUserService
    {
        public User? Authenticate(string username, string password)
            => _repository.GetUser(username, password);

        public bool Register(RegisterViewModel viewModel)
        {
            var user = viewModel.ToModel();

            if (_repository.UserExists(user.Username))
                return false;

            // Hash the password before storing it
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);

            _repository.AddUser(user);
            _repository.SaveChanges();

            return true;
        }
    }
}
