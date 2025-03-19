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
        {
            _moduleService = moduleService;
        }

        [HttpGet("get-by-lesson/{lessonId}")]
        public async Task<IActionResult> GetModulesByLessonId(int lessonId)
        {
            var modules = await _moduleService.GetModulesByLessonAndLanguageIdsAsync(lessonId);
            return Ok(modules);
        }
    }
}
