using System;
using System.Collections.Generic;
using Alkoholspiel.Core.Entities;

namespace Alkoholspiel.WebApi.Database.Entities;

public class GameEntity
{
    public GameEntity(Game game)
    {
        Id = game.Id;
        Name = game.Name;
        Author = game.Author;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public List<JokeEntity> Jokes { get; set; }

    public Game ToDomainEntity() => new Game(Id, Name, Author);
}