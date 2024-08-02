namespace QuizSystem.Models
{
    public class Choice : BaseEntity
    {
        public string Text { get; set; } = string.Empty;
        public bool IsRightAnswer { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
