using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DoeAqui.Domain.Core.Models;
using DoeAqui.Domain.Interfaces;
using DoeAqui.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DoeAqui.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity<T>
    {
        protected DoeAquiContext Context { get; set; }

        public Repository(DoeAquiContext context)
        {
            Context = context;
        }

        public void Add(T obj)
        {
            Context.Set<T>().Add(obj);
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().AsNoTracking().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return Context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public void Remove(Guid id)
        {
            Context.Set<T>().Remove(Context.Set<T>().Find(id));
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public void Update(T obj)
        {
            Context.Set<T>().Update(obj);
        }
    }
}