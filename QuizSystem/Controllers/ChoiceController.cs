using Microsoft.AspNetCore.Mvc;
using QuizSystem.Helpers;
using QuizSystem.Models;
using QuizSystem.Services.Choices;
using QuizSystem.ViewModels.Choice;

namespace QuizSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoiceController(IChoiceService service) : BaseController
    {
        [HttpPost("add")]
        public IActionResult Create(ChoiceViewModel viewModel)
        {
            if (!IsUserLoggedIn())
                return Unauthorized(new { message = "User not logged in" });

            if (GetLoggedInUserRole().ConvertStringToRoleType() != UserType.Instructor)
                return Forbid("Only instructors can add choices");

            service.Create(viewModel);
            return Ok(new { message = "Choice added successfully" });
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, ChoiceViewModel viewModel)
        {
            if (!IsUserLoggedIn())
                return Unauthorized(new { message = "User not logged in" });

            if (GetLoggedInUserRole().ConvertStringToRoleType() != UserType.Instructor)
                return Forbid("Only instructors can edit choices");

            if (service.Update(id, viewModel))
                return Ok(new { message = "Choice updated successfully" });

            return BadRequest(new { message = "Cannot edit choice" });
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (!IsUserLoggedIn())
                return Unauthorized(new { message = "User not logged in" });

            if (GetLoggedInUserRole().ConvertStringToRoleType() != UserType.Instructor)
                return Forbid("Only instructors can delete choices");

            if (service.Delete(id))
                return Ok(new { message = "Choice deleted successfully" });

            return BadRequest(new { message = "Cannot delete choice" });
        }
    }
}
