using Microsoft.AspNetCore.Mvc;
using QuizSystem.Helpers;
using QuizSystem.Models;
using QuizSystem.Services.Courses;
using QuizSystem.ViewModels.Course;

namespace QuizSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(ICourseService service) : BaseController
    {
        [HttpGet("get")]
        public IActionResult Get()
        {
            if (!IsUserLoggedIn())
                return Unauthorized(new { message = "User not logged in" });

            if (GetLoggedInUserRole().ConvertStringToRoleType() != UserType.Instructor)
                return Forbid("Only instructors can retrieve courses");

            int instructorId = GetLoggedInUserId();
            var courses = service.Get(instructorId);

            return Ok(courses);
        }

        [HttpPost("add")]
        public IActionResult Create(CourseViewModel viewModel)
        {
            if (!IsUserLoggedIn())
                return Unauthorized(new { message = "User not logged in" });

            if (GetLoggedInUserRole().ConvertStringToRoleType() != UserType.Instructor)
                return Forbid("Only instructors can add courses");

            service.Create(viewModel);
            return Ok(new { message = "Course added successfully" });
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, CourseViewModel viewModel)
        {
            if (!IsUserLoggedIn())
                return Unauthorized(new { message = "User not logged in" });

            if (GetLoggedInUserRole().ConvertStringToRoleType() != UserType.Instructor)
                return Forbid("Only instructors can edit courses");

            if (service.Update(id, viewModel))
                return Ok(new { message = "Course updated successfully" });

            return BadRequest(new { message = "Cannot edit course" });
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (!IsUserLoggedIn())
                return Unauthorized(new { message = "User not logged in" });

            if (GetLoggedInUserRole().ConvertStringToRoleType() != UserType.Instructor)
                return Forbid("Only instructors can delete courses");

            if (service.Delete(id))
                return Ok(new { message = "Course deleted successfully" });

            return BadRequest(new { message = "Cannot delete course" });
        }

        [HttpGet("enroll/{id}")]
        public IActionResult Enroll(int id)
        {
            if (!IsUserLoggedIn())
                return Unauthorized(new { message = "User not logged in" });

            if (GetLoggedInUserRole().ConvertStringToRoleType() != UserType.Student)
                return Forbid("Only students can enroll courses");

            //=> service.Enroll(id);
            return Ok();
        }
    }
}
