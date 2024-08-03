namespace QuizSystem.Models
{
    public class Question : BaseEntity
    {
        public string Text { get; set; } = string.Empty;
        public int Grade { get; set; }
        public QuestionLevel QuestionLevel { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<Choice> Choices { get; set; }
        public ICollection<QuizQuestion> QuizQuestions { get; set; }
    }

    public enum QuestionLevel
    {
        Simple,
        Medium,
        Hard
    }
}
