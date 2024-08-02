using QuizSystem.Models;
using QuizSystem.ViewModels.Course;

namespace QuizSystem.Helpers
{
    public static class Mapper
    {
        #region Course
        public static Course ToModel(this CourseViewModel viewModel)
        {
            return new Course
            {
                Name = viewModel.Name,
                CreditHours = viewModel.CreditHours
            };
        }
        #endregion
    }
}
