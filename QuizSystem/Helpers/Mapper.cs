using QuizSystem.Models;
using QuizSystem.ViewModels.Course;
using QuizSystem.ViewModels.Quiz;
using QuizSystem.ViewModels.User;

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

        #region User
        public static User ToModel(this RegisterViewModel viewModel)
        {
            return new User
            {
                Username = viewModel.Username,
                PasswordHash = viewModel.Password,
                Role = viewModel.Role
            };
        }
        #endregion

        #region Role
        public static string ConvertRoleTypeToString(this UserType type)
        {
            switch (type)
            {
                case UserType.Student:
                    return "Student";
                case UserType.Instructor:
                    return "Instructor";
                default:
                    return "Unknown type";
            }
        }
        #endregion
    }
}
