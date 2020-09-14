using CustomerManagement.Domain.Interfaces;
using CustomerManagement.Infrastructure.Data.Context;
using Eventos.IO.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CustomerManagement.Infrastructure.Data.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected CMContext Context;
        protected DbSet<TEntity> DbSet;

        public GenericRepository(CMContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public virtual void Add(TEntity obj) => DbSet.Add(obj);

        public void Update(TEntity obj) => DbSet.Update(obj);

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) 
            => DbSet.AsNoTracking().Where(predicate);

        public virtual IEnumerable<TEntity> GetAll() => DbSet.ToList();

        public virtual TEntity GetById(Guid id) => DbSet.AsNoTracking().FirstOrDefault(x => x.Id == id);

        public void Delete(TEntity entity) => Context.Remove(entity);

        public int SaveChanges() => Context.SaveChanges();

        public void Dispose() => Context.Dispose();
    }
}
