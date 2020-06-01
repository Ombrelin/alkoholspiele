using System;
using System.Collections.Generic;

namespace alkoholspiele.Models.DTO
{
    public class GameDTO
    {
        public Guid Id{ get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public ICollection<Joke> Jokes { get; set; }
    }
}