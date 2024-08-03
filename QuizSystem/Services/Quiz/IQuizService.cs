using QuizSystem.ViewModels.Quiz;

namespace QuizSystem.Services.Quizzes
{
    public interface IQuizService
    {
        IEnumerable<QuizViewModel> Get(int instructorId);
        void Create(QuizViewModel viewModel, int instructorId);
        bool Update(int id, QuizViewModel viewModel);
        bool Delete(int id);
    }
}
