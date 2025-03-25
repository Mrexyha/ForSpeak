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
        {
            _languageService = languageService;
        }

        [HttpGet("get-all-languages")]
        public async Task<IActionResult> GetLanguages()
        {
            var languages = await _languageService.GetAvailableLanguagesAsync();
            return Ok(languages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLanguageById(int id)
        {
            var language = await _languageService.GetLanguageByIdAsync(id);
            if (language == null)
                return NotFound();
            return Ok(language);
        }

        [HttpPut("update-language/{id}")]
        public async Task<IActionResult> UpdateLanguage(int id, [FromBody] LanguageEntity updatedLanguage)
        {
            var existingLanguage = await _languageService.GetLanguageByIdAsync(id);
            if (existingLanguage == null)
            {
                return NotFound();
            }

            existingLanguage.Name = updatedLanguage.Name;
            existingLanguage.Description = updatedLanguage.Description;
            existingLanguage.FlagImage = updatedLanguage.FlagImage;
            existingLanguage.CountryImage = updatedLanguage.CountryImage;

            await _languageService.UpdateLanguageAsync(existingLanguage);

            return NoContent();
        }
    }
}
