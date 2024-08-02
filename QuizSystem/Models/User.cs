namespace QuizSystem.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserType Role { get; set; }
    }

    public enum UserType
    {
        Student, Instructor
    }
}
