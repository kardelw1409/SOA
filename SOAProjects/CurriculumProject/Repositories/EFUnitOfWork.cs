using CurriculumProject.Context;
using CurriculumProject.Interfaces;
using CurriculumProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CurriculumProject.Repositories
{
    public class EFUnitOfWork<TEntity> : IUnitOfWork<TEntity>
        where TEntity : Entity
    {
        private DbContext db;

        public IRepository<TEntity> Repository { get; }

        private bool disposed = false;

        public EFUnitOfWork(DbContext dbContext)
        {
            db = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            Repository = new EntityRepository<TEntity>(db);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}