using FootballManager.Core.Dal;
using FootballManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FootballManager.Dal.Concrete.EntityFramework
{
   public class EfEntityRepostoryBase<TEntity, TContext> : IEntityRepostory<TEntity>
         where TEntity : EntityBase, new()
        where TContext : DbContext, new()
    {
        private DbContext dbContext = null;
        private DbSet<TEntity> table = null;

        public EfEntityRepostoryBase()
        {
            Build();
            table = dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            var _entity = dbContext.Entry<TEntity>(entity);
            _entity.State = EntityState.Added;
        }

        public void Delete(TEntity entity)
        {
            entity.IsActive = false;
            var _entity = dbContext.Entry<TEntity>(entity);
            _entity.State = EntityState.Modified;
        }

        public void Delete(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> entities = table.Where(filter);
            foreach (TEntity entity in entities)
                Delete(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, params string[] navigations)
        {
            var set = table.AsQueryable();
            navigations.ToList().ForEach(item => {
                set.Include(item);
            });
            return set.FirstOrDefault(filter);
        }

        public ICollection<TEntity> GetAll(params string[] navigations)
        {
            var set = table.AsQueryable();
            navigations.ToList().ForEach(item => {
                set.Include(item);
            });
            return set.ToList();
        }

        public ICollection<TEntity> GetMany(Expression<Func<TEntity, bool>> filter = null, params string[] navigations)
        {
            var set = table.AsQueryable();
            navigations.ToList().ForEach(item => {
                set.Include(item);
            });
            return filter == null ? set.ToList() : set.Where(filter).ToList();
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public int _Save()
        {
            return dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            var _entity = dbContext.Entry<TEntity>(entity);
            _entity.State = EntityState.Modified;
        }

        public void Dispose()
        {
            dbContext.DisposeAsync();
        }
        public void Build()
        {
            dbContext = new TContext();
        }
    }
}
