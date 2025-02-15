using BLL.Services.MainPage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForSpeak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IMainPageService _mainPageService;

        public LanguageController(IMainPageService mainService)
        {
            _mainPageService = mainService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLanguages()
        {
            var languages = await _mainPageService.GetAvailableLanguagesAsync();
            return Ok(languages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLanguageById(int id)
        {
            var language = await _mainPageService.GetLanguageByIdAsync(id);
            if (language == null)
                return NotFound();
            return Ok(language);
        }


    }
}
