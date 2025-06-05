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
            var pts = await _progressService.GetPointsForLanguageAsync(userId, languageId);
            return Ok(pts);
        }

        [HttpGet("total-points")]
        public async Task<IActionResult> GetTotalPoints()
        {
            var userId = GetCurrentUserId();
            var pts = await _progressService.GetTotalPointsAsync(userId);
            return Ok(pts);
        }

        [HttpGet("language/{languageId}/history")]
        public async Task<IActionResult> GetLanguageHistory(int languageId)
        {
            var history = await _progressService.GetMonthlyPointsForLanguageAsync(GetCurrentUserId(), languageId);
            return Ok(history);
        }

        [HttpGet("total-points/history")]
        public async Task<IActionResult> GetTotalHistory()
        {
            var history = await _progressService.GetMonthlyTotalPointsAsync(GetCurrentUserId());
            return Ok(history);
        }

        [HttpGet("lesson/{lessonId}/percent")]
        public async Task<IActionResult> GetLessonPercent(int lessonId)
        {
            var userId = GetCurrentUserId();
            var pct = await _progressService.GetLessonCompletionPercentAsync(userId, lessonId);
            return Ok(pct);
        }

        [HttpGet("language/{languageId}/percent")]
        public async Task<IActionResult> GetLanguageLessonsPercent(int languageId)
        {
            var userId = GetCurrentUserId();
            var percent = await _progressService.GetCompletedLessonsPercentAsync(userId, languageId);
            return Ok(percent);
        }

        [HttpGet("overall-percent")]
        public async Task<IActionResult> GetOverallLessonsPercent()
        {
            var userId = GetCurrentUserId();
            var percent = await _progressService.GetOverallLessonsPercentAsync(userId);
            return Ok(percent);
        }

    }
}
