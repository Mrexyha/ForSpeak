using AutoMapper;
using BLL.Models.User;
using BLL.Services.Users.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForSpeak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("{id}/languages")]
        public async Task<IActionResult> GetMyLanguages(int id)
        {
            var user = await _userService.GetUserWithLanguagesAsync(id);
            if (user == null) return NotFound();

            var result = user.UserLanguages
                .Select(ul => new {
                    languageId = ul.LanguageId,
                    name = ul.Language.Name,
                    description = ul.Language.Description,
                    flagImage = ul.Language.FlagImage,
                    countryImage = ul.Language.CountryImage,
                    progress = ul.Progress,
                    tasksCount = ul.Language.LessonsCount
                })
                .OrderBy(x => x.languageId)
                .ToList();

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] RegisterModel userModel)
        {
            if (id != userModel.Id)
            {
                return BadRequest("User ID mismatch.");
            }

            var updatedUser = await _userService.UpdateUserAsync(userModel);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
