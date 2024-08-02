namespace QuizSystem.Models
{
    public class Course : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int CreditHours { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }
    }
}
