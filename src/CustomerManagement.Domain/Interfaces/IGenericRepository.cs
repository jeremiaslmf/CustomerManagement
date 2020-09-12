using Eventos.IO.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CustomerManagement.Domain.Interfaces
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Delete(TEntity entity);
        int SaveChanges();
    }
}
