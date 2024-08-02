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

        public bool Update(int id, CourseViewModel viewModel)
        {
            var course = _repository.GetByIdWithTracking(id);
            if (course is null)
                return false;

            course.Name = viewModel.Name;
            course.CreditHours = viewModel.CreditHours;

            _repository.Update(course);
            _repository.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var course = _repository.GetByIdWithTracking(id);
            if (course is null)
                return false;

            _repository.Delete(course);
            _repository.SaveChanges();
            return true;
        }

        public CourseViewModel Enroll(int id)
        {
            var course = _repository.GetById(id);
            return course is not null ? course.ToViewModel() : new CourseViewModel();
        }
    }
}
