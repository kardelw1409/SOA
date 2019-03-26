using CurriculumProject.Interfaces;
using CurriculumProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CurriculumProject.Repositories
{
    public class EntityCrudService : IUnitOfWork
    {
        private DbContext db;
        private IRepository<Faculty> facultyRep;
        private IRepository<Department> departmentRep;
        private IRepository<Speciality> specialityRep;
        private IRepository<Subject> subjectRep;

        public EntityCrudService(DbContext context)
        {
            db = context;
        }

        public IRepository<Faculty> Faculties
        {
            get
            {
                if (facultyRep == null)
                {
                    facultyRep = new EntityRepository<Faculty>(db);
                }
                return facultyRep;
            }
        }

        public IRepository<Department> Departments
        {
            get
            {
                if (departmentRep == null)
                {
                    departmentRep = new EntityRepository<Department>(db);
                }
                return departmentRep;
            }
        }

        public IRepository<Speciality> Specialties
        {
            get
            {
                if (specialityRep == null)
                {
                    specialityRep = new EntityRepository<Speciality>(db);
                }
                return specialityRep;
            }
        }

        public IRepository<Subject> Subjects
        {
            get
            {
                if (subjectRep == null)
                {
                    subjectRep = new EntityRepository<Subject>(db);
                }
                return subjectRep;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}