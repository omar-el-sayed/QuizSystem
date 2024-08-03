using QuizSystem.Helpers;
using QuizSystem.Models;
using QuizSystem.Repository;
using QuizSystem.ViewModels.Question;

namespace QuizSystem.Services.Questions
{
    public class QuestionService(IGenericRepository<Question> _repository) : IQuestionService
    {
        public IEnumerable<QuestionViewModel> Get(int instructorId)
        {
            return _repository.Get(q => q.InstructorId == instructorId).ToViewModels();
        }

        public void Create(QuestionViewModel viewModel)
        {
            var question = viewModel.ToModel();
            _repository.Add(question);
            _repository.SaveChanges();
        }

        public bool Update(int id, QuestionViewModel viewModel)
        {
            var question = _repository.GetByIdWithTracking(id);
            if (question is null)
                return false;

            question.Text = viewModel.Text;
            question.Grade = viewModel.Grade;

            _repository.Update(question);
            _repository.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var question = _repository.GetByIdWithTracking(id);
            if (question is null)
                return false;

            _repository.Delete(question);
            _repository.SaveChanges();
            return true;
        }
    }
}
