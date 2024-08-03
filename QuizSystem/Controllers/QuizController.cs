using Microsoft.AspNetCore.Mvc;
using QuizSystem.Helpers;
using QuizSystem.Models;
using QuizSystem.Services.Quizzes;
using QuizSystem.ViewModels.Quiz;

namespace QuizSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController(IQuizService service) : BaseController
    {
        [HttpGet("get")]
        public IActionResult Get()
        {
            if (!IsUserLoggedIn())
                return Unauthorized(new { message = "User not logged in" });

            if (GetLoggedInUserRole().ConvertStringToRoleType() != UserType.Instructor)
                return Forbid("Only instructors can retrieve quizzes");

            int instructorId = GetLoggedInUserId();
            var quizzes = service.Get(instructorId);

            return Ok(quizzes);
        }

        [HttpPost("add")]
        public IActionResult Create(QuizViewModel viewModel)
        {
            if (!IsUserLoggedIn())
                return Unauthorized(new { message = "User not logged in" });

            if (GetLoggedInUserRole().ConvertStringToRoleType() != UserType.Instructor)
                return Forbid("Only instructors can add quizzes");

            int instructorId = GetLoggedInUserId();
            service.Create(viewModel, instructorId);

            return Ok(new { message = "Quiz added successfully" });
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, QuizViewModel viewModel)
        {
            if (!IsUserLoggedIn())
                return Unauthorized(new { message = "User not logged in" });

            if (GetLoggedInUserRole().ConvertStringToRoleType() != UserType.Instructor)
                return Forbid("Only instructors can edit quizzes");

            if (service.Update(id, viewModel))
                return Ok(new { message = "Quiz updated successfully" });

            return BadRequest(new { message = "Cannot edit quiz" });
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (!IsUserLoggedIn())
                return Unauthorized(new { message = "User not logged in" });

            if (GetLoggedInUserRole().ConvertStringToRoleType() != UserType.Instructor)
                return Forbid("Only instructors can delete quizzes");

            if (service.Delete(id))
                return Ok(new { message = "Quiz deleted successfully" });

            return BadRequest(new { message = "Cannot delete quiz" });
        }

        //[HttpGet("take")]
        //public IActionResult Take()
        //{
        //    if (!IsUserLoggedIn())
        //        return Unauthorized(new { message = "User not logged in" });

        //    if (GetLoggedInUserRole().ConvertStringToRoleType() != UserType.Student)
        //        return Forbid("Only students can take quizzes");


        //    return Ok(new { message = "Quiz retrieved successfully" });
        //}

        //[HttpGet("submit")]
        //public IActionResult Submit()
        //{
        //    if (!IsUserLoggedIn())
        //        return Unauthorized(new { message = "User not logged in" });

        //    if (GetLoggedInUserRole().ConvertStringToRoleType() != UserType.Student)
        //        return Forbid("Only students can submit quizzes");


        //    return Ok(new { message = "Quiz submited successfully" });
        //}
    }
}
