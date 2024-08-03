using QuizSystem.Models;
using QuizSystem.ViewModels.Choice;
using QuizSystem.ViewModels.Course;
using QuizSystem.ViewModels.Question;
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
        public static IEnumerable<CourseViewModel> ToViewModels(this IQueryable<Course> courses)
        {
            return courses.Select(c => c.ToViewModel());
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
        public static QuizViewModel ToViewModel(this Quiz quiz)
        {
            return new QuizViewModel
            {
                StartDate = quiz.StartDate,
                TotalGrade = quiz.TotalGrade,
                CourseId = quiz.CourseId
            };
        }
        public static IEnumerable<QuizViewModel> ToViewModels(this IQueryable<Quiz> quizzes)
        {
            return quizzes.Select(q => q.ToViewModel());
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

        public static UserType? ConvertStringToRoleType(this string type)
        {
            switch (type)
            {
                case "Student":
                    return UserType.Student;
                case "Instructor":
                    return UserType.Instructor;
                default:
                    return null;
            }
        }
        #endregion

        #region Question
        public static Question ToModel(this QuestionViewModel viewModel)
        {
            return new Question
            {
                Text = viewModel.Text,
                Grade = viewModel.Grade,
                QuestionLevel = viewModel.QuestionLevel
            };
        }
        public static QuestionViewModel ToViewModel(this Question question)
        {
            return new QuestionViewModel
            {
                Text = question.Text,
                Grade = question.Grade,
                QuestionLevel = question.QuestionLevel
            };
        }
        public static IEnumerable<QuestionViewModel> ToViewModels(this IQueryable<Question> questions)
        {
            return questions.Select(q => q.ToViewModel());
        }
        #endregion

        #region Choice
        public static Choice ToModel(this ChoiceViewModel viewModel)
        {
            return new Choice
            {
                Text = viewModel.Text,
                IsRightAnswer = viewModel.IsRightAnswer,
                QuestionId = viewModel.QuestionId
            };
        }
        #endregion
    }
}
