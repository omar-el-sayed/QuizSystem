using QuizSystem.Helpers;
using QuizSystem.Models;
using QuizSystem.Repository;
using QuizSystem.ViewModels.Course;

namespace QuizSystem.Services.Courses
{
    public class CourseService(IGenericRepository<Course> _repository) : ICourseService
    {
        public void Create(CourseViewModel viewModel)
        {
            var course = viewModel.ToModel();

            _repository.Add(course);
            _repository.SaveChanges();
        }
    }
}
