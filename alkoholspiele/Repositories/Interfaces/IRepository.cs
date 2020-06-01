using System;
using System.Collections.Generic;
using alkoholspiele.Models.Base;

namespace alkoholspiele.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        ICollection<T> GetAll();
        T GetById(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}