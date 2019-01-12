using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DoeAqui.Domain.Core.Models;

namespace DoeAqui.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable where T : Entity<T>
    {
        void Add(T obj);
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        void Update(T obj);
        void Remove(Guid id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        int SaveChanges();
    }
}