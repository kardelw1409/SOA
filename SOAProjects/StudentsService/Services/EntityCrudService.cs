using StudentsService.Context;
using StudentsService.Interfaces;
using StudentsService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace StudentsService.Services
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

        public async Task Create(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task Remove(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task<TEntity> FindById(int id)
        {
            return await DbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task Update(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<TEntity>> Get(Func<TEntity, bool> predicate)
        {
            return await QueryableExtensions.ToListAsync(DbContext.Set<TEntity>().Where(predicate).AsQueryable());
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}