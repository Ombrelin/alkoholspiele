using System;
using Alkoholspiel.Core;
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
    public IActionResult CreateGame(/*[FromBody] UpsertGameDTO dto*/)
    {
        throw new NotImplementedException();
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