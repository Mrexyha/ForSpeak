using BLL.Models.Modules;
using BLL.Models.Tasks;
using BLL.Services.Lessons;
using BLL.Services.Tasks.Speaking;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForSpeak.Controllers
{
    [Route("api/languages/{languageId}/lessons/{lessonId}/speaking")]
    [ApiController]
    public class SpeakingModuleController : ControllerBase
    {
        private readonly ILessonsService _lessonService;
        private readonly ISpeakingModuleService _speakingService;

        public SpeakingModuleController(
            ILessonsService lessonService,
            ISpeakingModuleService speakingService)
        {
            _lessonService = lessonService;
            _speakingService = speakingService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int languageId, int lessonId)
        {
            var lesson = await _lessonService.GetLessonByLanguageAndIdAsync(languageId, lessonId);
            if (lesson == null) return NotFound();

            var module = await _speakingService.GetByLessonIdAsync(lessonId);
            if (module == null) return NotFound();
            return Ok(module);
        }

        [HttpPost("phrases")]
        public async Task<IActionResult> AddPhrase(
        int languageId, int lessonId,
        [FromBody] SpeakingPhraseModel model)
        {
            var added = await _speakingService.AddPhraseAsync(lessonId, model);
            return CreatedAtAction(
                nameof(Get),
                new { languageId, lessonId },
                added
            );
        }

        [HttpPut]
        public async Task<IActionResult> Update(int languageId, int lessonId, [FromBody] SpeakingModuleModel model)
        {
            var newAvg = await _speakingService.RecalculateAverageAccuracyAsync(lessonId);
            return Ok(new { AverageAccuracy = newAvg });
        }

        [HttpDelete("phrases/{phraseId}")]
        public async Task<IActionResult> DeletePhrase(int languageId, int lessonId, int phraseId)
        {
            await _speakingService.DeletePhraseAsync(phraseId);
            return NoContent();
        }
    }
}
