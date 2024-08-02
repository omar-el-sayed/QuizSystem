using QuizSystem.Models;

namespace QuizSystem.ViewModels.User
{
    public class RegisterViewModel
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UserType Role { get; set; }
    }
}
