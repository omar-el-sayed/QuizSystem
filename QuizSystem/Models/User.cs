namespace QuizSystem.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public UserType UserType { get; set; }
    }

    public enum UserType
    {
        Student,
        Instructor
    }
}
