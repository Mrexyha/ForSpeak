using BLL.Models.Modules;
using BLL.Models.Results;
using BLL.Services.Lessons;
using BLL.Services.Tasks.Reading;
using BLL.Services.Tasks.Speaking;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForSpeak.Controllers
{
    [Route("api/languages/{languageId}/lessons/{lessonId}/reading")]
    [ApiController]
    public class ReadingModuleController : ControllerBase
    {

        private readonly ILessonsService _lessonService;
        private readonly ISpeakingModuleService _speakingService;

        private readonly IReadingModuleService _readingService;

        public ReadingModuleController(IReadingModuleService readingService, ILessonsService lessonService)
        {
            _readingService = readingService;
            _lessonService = lessonService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int languageId, int lessonId)
        {
            var module = await _readingService.GetByLessonIdAsync(lessonId);
            if (module == null) return NotFound();
            return Ok(module);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int languageId,
            int lessonId,
            [FromBody] ReadingModuleModel model)
        {
            await _readingService.AddAsync(lessonId, model);
            return CreatedAtAction(
                nameof(Get),
                new { languageId = languageId, lessonId = lessonId },
                model
            );
        }

        [HttpPut]
        public async Task<IActionResult> Update(
           int languageId,
           int lessonId,
           [FromBody] ReadingModuleModel model)
        {
            try
            {
                await _readingService.UpdateAsync(lessonId, model);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int languageId, int lessonId)
        {
            await _readingService.DeleteAsync(lessonId);
            return NoContent();
        }

        [HttpGet("results/{userId}")]
        public async Task<IActionResult> GetResult(
            int languageId,
            int lessonId,
            int userId)
        {
            var lesson = await _lessonService.GetLessonByLanguageAndIdAsync(languageId, lessonId);
            if (lesson == null)
                return NotFound($"Lesson {lessonId} in language {languageId} not found.");

            var score = await _readingService.GetComprehensionScoreAsync(lessonId, userId);
            if (score == null)
                return NotFound($"Reading score for user {userId} not found.");

            return Ok(new { UserId = userId, ComprehensionScore = score });
        }

        [HttpPost("results/{userId}")]
        public async Task<IActionResult> SaveResult(
            int languageId,
            int lessonId,
            int userId,
            [FromBody] ReadingResultModel result)
        {
            var lesson = await _lessonService.GetLessonByLanguageAndIdAsync(languageId, lessonId);
            if (lesson == null)
                return NotFound($"Lesson {lessonId} in language {languageId} not found.");

            await _readingService.UpdateUserResultAsync(lessonId, userId, result.ComprehensionScore);

            return Ok(new { UserId = userId, ComprehensionScore = result.ComprehensionScore });
        }
    }
}
