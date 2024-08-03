using QuizSystem.ViewModels.Course;

namespace QuizSystem.Services.Courses
{
    public interface ICourseService
    {
        IEnumerable<CourseViewModel> Get(int instructorId);
        void Create(CourseViewModel viewModel);
        bool Update(int id, CourseViewModel viewModel);
        bool Delete(int id);
        CourseViewModel Enroll(int id);
    }
}
