namespace QuizSystem.ViewModels.Choice
{
    public class ChoiceViewModel
    {
        public string Text { get; set; } = string.Empty;
        public bool IsRightAnswer { get; set; }
        public int QuestionId { get; set; }
    }
}
