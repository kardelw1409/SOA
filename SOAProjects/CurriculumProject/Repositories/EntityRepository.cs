using CurriculumProject.Interfaces;
using CurriculumProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CurriculumProject.Repositories
{
    public class EntityRepository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        private DbContext dbContext;
        private DbSet<TEntity> dbSet;

        public EntityRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            dbSet.Add(entity);
        }


        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return dbSet.Where(predicate);
        }

        public TEntity Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet;

        }

        public void Update(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;

        }
    }
}