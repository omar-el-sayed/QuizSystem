namespace QuizSystem.Models
{
    public class Instructor
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public double Salary { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }
    }
}
