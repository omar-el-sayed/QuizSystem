using QuizSystem.Helpers;
using QuizSystem.Models;
using QuizSystem.Repository;
using QuizSystem.ViewModels.Choice;

namespace QuizSystem.Services.Choices
{
    public class ChoiceService(IGenericRepository<Choice> _repository) : IChoiceService
    {
        public void Create(ChoiceViewModel viewModel)
        {
            var choice = viewModel.ToModel();
            _repository.Add(choice);
            _repository.SaveChanges();
        }

        public bool Update(int id, ChoiceViewModel viewModel)
        {
            var choice = _repository.GetByIdWithTracking(id);
            if (choice is null)
                return false;

            choice.Text = viewModel.Text;
            choice.IsRightAnswer = viewModel.IsRightAnswer;
            choice.QuestionId = viewModel.QuestionId;

            _repository.Update(choice);
            _repository.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var choice = _repository.GetByIdWithTracking(id);
            if (choice is null)
                return false;

            _repository.Delete(choice);
            _repository.SaveChanges();
            return true;
        }
    }
}
