using QuizSystem.ViewModels.Quiz;

namespace QuizSystem.Services.Quizzes
{
    public interface IQuizService
    {
        void Create(QuizViewModel viewModel);
        bool Update(int id, QuizViewModel viewModel);
        bool Delete(int id);
    }
}
