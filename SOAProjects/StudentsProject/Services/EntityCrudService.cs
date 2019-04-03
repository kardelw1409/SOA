using StudentsProject.Context;
using StudentsProject.Interfaces;
using StudentsProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentsProject.Services
{
    public class EntityCrudService<TEntity> : IEntityCrudService<TEntity>
        where TEntity : Entity
    {
        private DbContext db;

        protected IDbFactory DbFactory { get; private set; }

        protected DbContext DbContext
        {
            get { return db ?? (db = DbFactory.Init()); }
        }

        public EntityCrudService(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }

        public void Create(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            DbContext.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
            DbContext.SaveChanges();
        }

        public TEntity FindById(int id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>().AsNoTracking().ToList();
        }

        public void Update(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.SaveChanges();
        }


        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return DbContext.Set<TEntity>().AsNoTracking().Where(predicate).ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}