using BLL.Services.Lessons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForSpeak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonsService _lessonsService;

        public LessonsController(ILessonsService lessonsService)
        {
            _lessonsService = lessonsService;
        }

        [HttpGet("get-lessons-by-language-id/{languageId}")]
        public async Task<IActionResult> GetLessonsByLanguage(int languageId)
        {
            var lessons = await _lessonsService.GetLessonsByLanguageIdAsync(languageId);
            return Ok(lessons);
        }
    }
}
