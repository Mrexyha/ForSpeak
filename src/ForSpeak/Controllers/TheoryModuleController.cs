using BLL.Models.Modules;
using BLL.Services.Lessons;
using BLL.Services.Tasks.Theory;
using Microsoft.AspNetCore.Mvc;

[Route("api/languages/{languageId}/lessons/{lessonId}/theory")]
[ApiController]
public class TheoryModuleController : ControllerBase
{
    private readonly ILessonsService _lessonService;
    private readonly ITheoryModuleService _theoryService;

    public TheoryModuleController(
        ILessonsService lessonService,
        ITheoryModuleService theoryService)
    {
        _lessonService = lessonService;
        _theoryService = theoryService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(int languageId, int lessonId)
    {
        var lesson = await _lessonService.GetLessonByLanguageAndIdAsync(languageId, lessonId);
        if (lesson == null)
            return NotFound($"Lesson {lessonId} in language {languageId} not found.");

        if (lesson.Theory == null)
            return NotFound("Theory module not added yet.");

        return Ok(lesson.Theory);
    }

    [HttpPost]
    public async Task<IActionResult> Create(int languageId, int lessonId, [FromBody] TheoryModuleModel model)
    {
        if (model == null)
            return BadRequest("Invalid theory data.");

        var lesson = await _lessonService.GetLessonByLanguageAndIdAsync(languageId, lessonId);
        if (lesson == null)
            return NotFound($"Lesson {lessonId} in language {languageId} not found.");

        await _theoryService.AddAsync(lessonId, model);
        return CreatedAtAction(
            nameof(Get),
            new { languageId, lessonId },
            model
        );
    }

    [HttpPut]
    public async Task<IActionResult> Update(int languageId, int lessonId, [FromBody] TheoryModuleModel model)
    {
        if (model == null)
            return BadRequest("Invalid theory data.");

        var lesson = await _lessonService.GetLessonByLanguageAndIdAsync(languageId, lessonId);
        if (lesson == null)
            return NotFound($"Lesson {lessonId} in language {languageId} not found.");

        try
        {
            await _theoryService.UpdateAsync(lessonId, model);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Theory module not found for this lesson.");
        }

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int languageId, int lessonId)
    {
        var lesson = await _lessonService.GetLessonByLanguageAndIdAsync(languageId, lessonId);
        if (lesson == null)
            return NotFound($"Lesson {lessonId} in language {languageId} not found.");

        await _theoryService.DeleteAsync(lessonId);
        return NoContent();
    }
}
