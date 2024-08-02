using QuizSystem.Models;
using QuizSystem.ViewModels.Course;
using QuizSystem.ViewModels.Quiz;

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
        public static CourseViewModel ToViewModel(this Course course)
        {
            return new CourseViewModel
            {
                Name = course.Name,
                CreditHours = course.CreditHours
            };
        }
        #endregion

        #region Quiz
        public static Quiz ToModel(this QuizViewModel viewModel, int instructorId)
        {
            return new Quiz
            {
                StartDate = viewModel.StartDate,
                TotalGrade = viewModel.TotalGrade,
                InstructorId = instructorId,
                CourseId = viewModel.CourseId
            };
        }
        #endregion
    }
}
