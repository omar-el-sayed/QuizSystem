using QuizSystem.Models;

namespace QuizSystem.ViewModels.Question
{
    public class QuestionViewModel
    {
        public string Text { get; set; } = string.Empty;
        public int Grade { get; set; }
        public QuestionLevel QuestionLevel { get; set; }
    }
}
