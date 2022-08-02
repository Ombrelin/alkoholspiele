using System;
using System.Threading.Tasks;
using Alkoholspiel.Core;
using Alkoholspiel.Core.Contracts;
using Alkoholspiel.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Alkoholspiel.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GamesController : ControllerBase
{
    private readonly AlkoholspielApplication application;

    public GamesController(AlkoholspielApplication application)
    {
        this.application = application;
    }

    [HttpPost]
    public async Task<ActionResult<IGame>> CreateGame([FromBody] CreateGameRequest dto)
    {
        IGame game = await this.application.CreateGame(dto);
        return Created("", game);
    }

    [HttpGet("{gameId:Guid}")]
    public IActionResult GetGame(Guid gameId)
    {
        throw new NotImplementedException();
    }

    [HttpPost("{gameId:Guid}")]
    public IActionResult AddJoke(/*Guid gameId, [FromBody] UpsertJokeDTO dto*/)
    {
        throw new NotImplementedException();
    }
}