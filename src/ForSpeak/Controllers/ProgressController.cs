using BLL.Services.Progress;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ForSpeak.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgressController : ControllerBase
    {
        private readonly IUserLessonProgressService _progressService;

        public ProgressController(IUserLessonProgressService progressService)
            => _progressService = progressService;

        private int GetCurrentUserId()
        {
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return idClaim != null
                ? int.Parse(idClaim)
                : throw new UnauthorizedAccessException("User ID claim missing");
        }

        [HttpGet("language/{languageId}/points")]
        public async Task<IActionResult> GetLanguagePoints(int languageId)
        {
            var userId = GetCurrentUserId();
            var pts = await _progressService.GetPointsForLanguage(userId, languageId);
            return Ok(pts);
        }

        [HttpGet("total-points")]
        public async Task<IActionResult> GetTotalPoints()
        {
            var userId = GetCurrentUserId();
            var pts = await _progressService.GetTotalPoints(userId);
            return Ok(pts);
        }
    }
}
