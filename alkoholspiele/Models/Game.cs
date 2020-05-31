using System.Collections.Generic;
using alkoholspiele.Models.Base;

namespace alkoholspiele.Models
{
    public class Game : BaseEntity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public ICollection<Joke> Jokes { get; set; }
    }
}