using BLL.Models.Modules;
using BLL.Services.Lessons;
using BLL.Services.Tasks.Quiz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForSpeak.Controllers
{
    [Route("api/languages/{languageId}/lessons/{lessonId}/quiz")]
    [ApiController]
    public class QuizModuleController : ControllerBase
    {
        private readonly ILessonsService _lessonService;
        private readonly IQuizModuleService _quizService;

        public QuizModuleController(ILessonsService lessonService, IQuizModuleService quizService)
        {
            _lessonService = lessonService;
            _quizService = quizService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int languageId, int lessonId)
        {
            var quiz = await _quizService.GetByLessonIdAsync(lessonId);
            if (quiz == null) return NotFound();
            return Ok(quiz);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int languageId, int lessonId, [FromBody] QuizModuleModel model)
        {
            await _quizService.AddAsync(lessonId, model);
            return CreatedAtAction(nameof(Get), new { languageId, lessonId }, model);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int languageId, int lessonId, [FromBody] QuizModuleModel model)
        {
            try
            {
                await _quizService.UpdateAsync(lessonId, model);
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
            await _quizService.DeleteAsync(lessonId);
            return NoContent();
        }
    }
}
