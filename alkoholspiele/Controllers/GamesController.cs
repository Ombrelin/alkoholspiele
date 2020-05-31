using alkoholspiele.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace alkoholspiele.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController:ControllerBase
    {
        [HttpPost]
        public IActionResult CreateGame([FromBody] UpsertGameDTO dto)
        {
            return Ok();
        }
    }
}