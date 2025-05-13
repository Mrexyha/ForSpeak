using BLL.Services.Progress;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ForSpeak.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
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

        [HttpGet("language/{languageId}/history")]
        public async Task<IActionResult> GetLanguageHistory(int languageId)
        {
            var history = await _progressService.GetMonthlyPointsForLanguage(GetCurrentUserId(), languageId);
            return Ok(history);
        }

        [HttpGet("total-points/history")]
        public async Task<IActionResult> GetTotalHistory()
        {
            var history = await _progressService.GetMonthlyTotalPoints(GetCurrentUserId());
            return Ok(history);
        }
    }
}
