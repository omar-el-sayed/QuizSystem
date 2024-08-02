using Microsoft.AspNetCore.Mvc;
using QuizSystem.Services.Courses;
using QuizSystem.ViewModels.Course;

namespace QuizSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(ICourseService service) : BaseController
    {
        [HttpPost("add")]
        public IActionResult Create(CourseViewModel viewModel)
        {
            if (!IsUserLoggedIn())
                return Unauthorized(new { message = "User not logged in" });

            if (GetLoggedInUserRole() != "Instructor")
                return Forbid("Only instructors can add courses");

            service.Create(viewModel);
            return Ok(new { message = "Course added successfully" });
        }

        [HttpPut("update/{id}")]
        public bool Update(int id, CourseViewModel viewModel)
            => service.Update(id, viewModel);

        [HttpDelete("delete/{id}")]
        public bool Delete(int id)
            => service.Delete(id);

        //[HttpGet("enroll/{id}")]
        //public CourseViewModel Enroll(int id)
        //    => service.Enroll(id);
    }
}
