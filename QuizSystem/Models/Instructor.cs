namespace QuizSystem.Models
{
    public class Instructor : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public double Salary { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
