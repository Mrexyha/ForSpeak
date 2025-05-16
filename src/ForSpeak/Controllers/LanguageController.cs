using BLL.Models.Languages;
using BLL.Services.Languages;
using DAL.Entities.Languages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForSpeak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;
        public LanguageController(ILanguageService languageService)
            => _languageService = languageService;

        [HttpGet("get-all-languages")]
        public async Task<IActionResult> GetLanguages()
        {
            var langs = await _languageService.GetAvailableLanguagesAsync();
            return Ok(langs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLanguage(int id)
        {
            var lang = await _languageService.GetLanguageByIdAsync(id);
            if (lang == null) return NotFound();
            return Ok(lang);
        }

        [HttpPut("update-language/{id}")]
        public async Task<IActionResult> UpdateLanguage(int id, [FromBody] LanguageModel model)
        {
            if (id != model.Id) return BadRequest();
            try
            {
                await _languageService.UpdateLanguageAsync(model);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
