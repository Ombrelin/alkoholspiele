using System;

namespace alkoholspiele.Models.Base
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
    }
}