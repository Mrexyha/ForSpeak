using BLL.Models.Tasks;
using BLL.Services.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForSpeak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskLangController : ControllerBase
    {
        private readonly ILangTaskService _langTaskService;

        public TaskLangController(ILangTaskService langTaskService)
        {
            _langTaskService = langTaskService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskLangModel model)
        {
            var createdTask = await _langTaskService.CreateTaskAsync(model);
            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _langTaskService.GetTaskByIdAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpGet("{id}/content")]
        public async Task<IActionResult> GetTaskContent(int id)
        {
            var content = await _langTaskService.GetTaskContentAsync(id);
            if (content == null) return NotFound();
            return Ok(content);
        }
    }
}
