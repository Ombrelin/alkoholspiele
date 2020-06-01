using System;

namespace alkoholspiele.Models.DTO
{
    public class UpsertJokeDTO
    {
        public Guid Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public int Number { get; set; }
    }
}