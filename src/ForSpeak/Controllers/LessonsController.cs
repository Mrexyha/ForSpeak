using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForSpeak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        public LessonsController()
        {

        }

        [HttpGet("get-all-lessons")]
        public IActionResult GetAllLessons()
        {
            try
            {
                var _result = 0;
                return Ok(_result);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }
    }
}
