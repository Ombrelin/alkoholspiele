using System;
using alkoholspiele.Models.DTO;
using alkoholspiele.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace alkoholspiele.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController:ControllerBase
    {

        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        public IActionResult CreateGame([FromBody] UpsertGameDTO dto)
        {
            var game = this._gameService.CreateGame(dto);   
            return Ok(game);
        }

        [HttpGet("{gameId:Guid}")]
        public IActionResult GetGame(Guid gameId)
        {
            var game = this._gameService.GetGameById(gameId);
            return Ok(game);
        }

        [HttpPost("{gameId:Guid}")]
        public IActionResult AddJoke(Guid gameId, [FromBody] UpsertJokeDTO dto)
        {
            this._gameService.AddJoke(gameId, dto);
            return Ok();
        }
    }
}