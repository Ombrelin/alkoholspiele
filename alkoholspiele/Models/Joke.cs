﻿using alkoholspiele.Models.Base;

namespace alkoholspiele.Models
{
    public class Joke : BaseEntity
    {
        public string Author { get; set; }
        public string Content { get; set; }
        public int Number { get; set; }
    }
}