using QuizSystem.ViewModels.Question;

namespace QuizSystem.Services.Questions
{
    public interface IQuestionService
    {
        IEnumerable<QuestionViewModel> Get(int instructorId);
        void Create(QuestionViewModel viewModel);
        bool Update(int id, QuestionViewModel viewModel);
        bool Delete(int id);
    }
}
