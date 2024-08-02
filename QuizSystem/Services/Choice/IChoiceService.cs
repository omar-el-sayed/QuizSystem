using QuizSystem.ViewModels.Choice;

namespace QuizSystem.Services.Choices
{
    public interface IChoiceService
    {
        void Create(ChoiceViewModel viewModel);
        bool Update(int id, ChoiceViewModel viewModel);
        bool Delete(int id);
    }
}
