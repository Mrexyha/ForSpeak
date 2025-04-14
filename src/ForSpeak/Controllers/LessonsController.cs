using BLL.Models.Lessons;
using BLL.Services.Lessons;
using DAL.Entities.Enums;
using DAL.Entities.Lessons;
using DAL.Entities.Modules;
using DAL.Entities.Tasks;
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

        [HttpGet("get-lesson-by-id/{languageId}/{id}")]
        public async Task<IActionResult> GetLessonById(int languageId, int id)
        {
            var lesson = await _lessonsService.GetLessonByLanguageAndIdAsync(languageId, id);

            if (lesson == null)
            {
                return NotFound();
            }

            return Ok(lesson);
        }

        [HttpPost("add-lesson-by-language-id/{languageId}")]
        public async Task<IActionResult> AddLesson(int languageId, [FromBody] LessonModel lessonModel)
        {
            if (lessonModel == null)
            {
                return BadRequest("Invalid lesson data.");
            }

            var lessonEntity = new LessonEntity
            {
                LanguageId = languageId,
                LanguageName = lessonModel.LanguageName,
                Title = lessonModel.Title,
                ImageUrl = lessonModel.ImageUrl,
                Level = lessonModel.Level,
                Modules = lessonModel.Modules?.Select(m => new ModuleEntity
                {
                    Type = m.Type,
                    Title = m.Title,
                    Tasks = new List<TaskLangEntity>()
                }).ToList() ?? new List<ModuleEntity>()
            };

            var createdLesson = await _lessonsService.AddLessonAsync(lessonEntity);

            return CreatedAtAction(
                nameof(GetLessonById),
                new { languageId = languageId, id = createdLesson.Id },
                createdLesson
            );
        }

        [HttpPut("update-lesson/{languageId}/{lessonId}")]
        public async Task<IActionResult> UpdateLesson(int languageId, int lessonId, [FromBody] LessonModel lessonModel)
        {
            if (lessonModel == null)
                return BadRequest("Invalid lesson data.");

            var updatedLesson = await _lessonsService.UpdateLessonAsync(languageId, lessonId, lessonModel);

            if (updatedLesson == null)
                return NotFound("Lesson not found.");

            return Ok(updatedLesson);
        }

        [HttpDelete("delete-lesson/{languageId}/{lessonId}")]
        public async Task<IActionResult> DeleteLesson(int languageId, int lessonId)
        {
            var isDeleted = await _lessonsService.DeleteLessonAsync(languageId, lessonId);

            if (!isDeleted)
                return NotFound("Lesson not found.");

            return NoContent();
        }
    }
}
