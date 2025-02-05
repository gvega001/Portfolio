using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.Services;
using System.Threading.Tasks;

namespace Portfolio.Web.Controllers
{
    [ApiController]
    [Route("api/ai")]
    public class AIController : ControllerBase
    {
        private readonly AIService _aiService;

        public AIController(AIService aiService)
        {
            _aiService = aiService;
        }

        [HttpGet("chat")]
        public async Task<IActionResult> GetAIResponse([FromQuery] string prompt)
        {
            var response = await _aiService.GetAIResponse(prompt);
            return Ok(new { response });
        }
    }
}
