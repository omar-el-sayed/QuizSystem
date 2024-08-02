using QuizSystem.Models;
using QuizSystem.ViewModels.User;

namespace QuizSystem.Services.UserManagement
{
    public interface IUserService
    {
        User? Authenticate(string username, string password);
        bool Register(RegisterViewModel viewModel);
    }
}
