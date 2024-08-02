using Microsoft.AspNetCore.Mvc;
using QuizSystem.Helpers;
using QuizSystem.Models;
using QuizSystem.Services.Questions;
using QuizSystem.ViewModels.Question;

namespace QuizSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController(IQuestionService service) : BaseController
    {
        [HttpPost("add")]
        public IActionResult Create(QuestionViewModel viewModel)
        {
            if (!IsUserLoggedIn())
                return Unauthorized(new { message = "User not logged in" });

            if (GetLoggedInUserRole().ConvertStringToRoleType() != UserType.Instructor)
                return Forbid("Only instructors can add questions");

            service.Create(viewModel);
            return Ok(new { message = "Question added successfully" });
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, QuestionViewModel viewModel)
        {
            if (!IsUserLoggedIn())
                return Unauthorized(new { message = "User not logged in" });

            if (GetLoggedInUserRole().ConvertStringToRoleType() != UserType.Instructor)
                return Forbid("Only instructors can edit questions");

            if (service.Update(id, viewModel))
                return Ok(new { message = "Question updated successfully" });

            return BadRequest(new { message = "Cannot edit question" });
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (!IsUserLoggedIn())
                return Unauthorized(new { message = "User not logged in" });

            if (GetLoggedInUserRole().ConvertStringToRoleType() != UserType.Instructor)
                return Forbid("Only instructors can delete questions");

            if (service.Delete(id))
                return Ok(new { message = "Question deleted successfully" });

            return BadRequest(new { message = "Cannot delete question" });
        }
    }
}
