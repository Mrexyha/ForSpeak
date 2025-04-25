using BLL.Models.Modules;
using BLL.Services.Tasks.Reading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForSpeak.Controllers
{
    [Route("api/languages/{languageId}/lessons/{lessonId}/reading")]
    [ApiController]
    public class ReadingModuleController : ControllerBase
    {
        private readonly IReadingModuleService _readingService;

        public ReadingModuleController(IReadingModuleService readingService)
        {
            _readingService = readingService;
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
    }
}
