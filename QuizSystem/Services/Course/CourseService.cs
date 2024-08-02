using QuizSystem.Models;
using QuizSystem.Repository;

namespace QuizSystem.Services.Courses
{
    public class CourseService(IGenericRepository<Course> _repository) : ICourseService
    {
        public void Create()
        {
            _repository.SaveChanges();
        }
    }
}
