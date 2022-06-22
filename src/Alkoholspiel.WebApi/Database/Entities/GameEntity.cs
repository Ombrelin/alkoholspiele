using System;
using System.Collections.Generic;

namespace Alkoholspiel.WebApi.Database.Entities;

public class GameEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public List<JokeEntity> Jokes { get; set; }
}