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
    }
}
