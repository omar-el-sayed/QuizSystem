namespace QuizSystem.Models
{
    public class Question : BaseEntity
    {
        public string Text { get; set; } = string.Empty;
        public int Grade { get; set; }
        public ICollection<Choice> Choices { get; set; }
        public ICollection<QuizQuestion> QuizQuestions { get; set; }
    }
}
