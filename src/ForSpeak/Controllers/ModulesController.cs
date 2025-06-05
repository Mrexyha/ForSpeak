using BLL.Models.Modules;
using BLL.Services.Modules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForSpeak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly IModuleService _moduleService;

        public ModulesController(IModuleService moduleService)
            => _moduleService = moduleService;

        [HttpPost("theory/{lessonId}")]
        public async Task<IActionResult> UpsertTheory(int lessonId, [FromBody] TheoryModuleModel model)
        {
            var result = await _moduleService.CreateOrUpdateTheoryAsync(lessonId, model);
            return Ok(result);
        }

        [HttpPost("vocabulary/{lessonId}")]
        public async Task<IActionResult> UpsertVocabulary(int lessonId, [FromBody] VocabularyModuleModel model)
        {
            var result = await _moduleService.CreateOrUpdateVocabularyAsync(lessonId, model);
            return Ok(result);
        }

        [HttpPost("quiz/{lessonId}")]
        public async Task<IActionResult> UpsertQuiz(int lessonId, [FromBody] QuizModuleModel model)
        {
            var result = await _moduleService.CreateOrUpdateQuizAsync(lessonId, model);
            return Ok(result);
        }

        [HttpPost("reading/{lessonId}")]
        public async Task<IActionResult> UpsertReading(int lessonId, [FromBody] ReadingModuleModel model)
        {
            var result = await _moduleService.CreateOrUpdateReadingAsync(lessonId, model);
            return Ok(result);
        }

        [HttpPost("speaking/{lessonId}")]
        public async Task<IActionResult> UpsertSpeaking(int lessonId, [FromBody] SpeakingModuleModel model)
        {
            var result = await _moduleService.CreateOrUpdateSpeakingAsync(lessonId, model);
            return Ok(result);
        }

        [HttpDelete("{lessonId}/{moduleId}")]
        public async Task<IActionResult> Delete(int lessonId, int moduleId)
        {
            var deleted = await _moduleService.DeleteModuleAsync(lessonId, moduleId);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
