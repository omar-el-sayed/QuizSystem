using Microsoft.AspNetCore.Mvc;
using QuizSystem.Services.Courses;
using QuizSystem.ViewModels.Course;

namespace QuizSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(ICourseService service) : ControllerBase
    {
        [HttpPost]
        public void Create(CourseViewModel viewModel)
            => service.Create(viewModel);

        [HttpPut("{id}")]
        public bool Update(int id, CourseViewModel viewModel)
            => service.Update(id, viewModel);

        [HttpDelete]
        public bool Delete(int id)
            => service.Delete(id);

        [HttpGet("{id}")]
        public CourseViewModel Enroll(int id)
            => service.Enroll(id);
    }
}
