using AutoMapper;
using BLL.Services.MainPage;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ForSpeak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainPageController : ControllerBase
    {
        private readonly IMainPageService _mainPageService;
        private readonly IMapper _mapper;

        public MainPageController(IMainPageService mainPageService, IMapper mapper)
        {
            _mainPageService = mainPageService;
            _mapper = mapper;
        }

        [HttpGet("get-all-languages")]
        public async Task<IActionResult> GetAllLanguages()
        {
            var languages = await _mainPageService.GetAllLanguagesAsync();
            return Ok(languages);
        }
    }
}
