using CurriculumProject.Interfaces;
using CurriculumProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CurriculumProject.Services
{
    public class EntityCrudService<TEntity> : IEntityCrudService<TEntity>
        where TEntity : Entity
    {
        //IUnitOfWork Database { get; set; }
        private DbContext db;

        public EntityCrudService(DbContext dbContext)
        {
            db = dbContext;
        }

        public void Create(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            db.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
            db.SaveChanges();
        }

        public TEntity FindById(int id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().AsNoTracking().ToList();
        }

        public void Update(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }


        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return db.Set<TEntity>().AsNoTracking().Where(predicate).ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}