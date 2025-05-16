using BLL.Models.Modules;
using BLL.Services.Lessons;
using BLL.Services.Tasks.Vocabulary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForSpeak.Controllers
{
    [Route("api/languages/{languageId}/lessons/{lessonId}/vocabulary")]
    [ApiController]
    public class VocabularyModuleController : ControllerBase
    {
        private readonly IVocabularyModuleService _vocabService;
        private readonly ILessonsService _lessonService;

        public VocabularyModuleController(
            ILessonsService lessonService,
            IVocabularyModuleService vocabService)
        {
            _lessonService = lessonService;
            _vocabService = vocabService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int languageId, int lessonId)
        {
            var lesson = await _lessonService.GetLessonByLanguageAndIdAsync(languageId, lessonId);
            if (lesson == null) return NotFound();

            var vocab = await _vocabService.GetByLessonIdAsync(lessonId);
            if (vocab == null) return NotFound();

            return Ok(vocab);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int languageId, int lessonId, [FromBody] VocabularyModuleModel model)
        {
            await _vocabService.AddAsync(lessonId, model);
            return CreatedAtAction(nameof(Get), new { languageId, lessonId }, model);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int languageId, int lessonId, [FromBody] VocabularyModuleModel model)
        {
            try
            {
                await _vocabService.UpdateAsync(lessonId, model);
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
            await _vocabService.DeleteAsync(lessonId);
            return NoContent();
        }
    }
}
