using CurriculumProject.Context;
using CurriculumProject.Interfaces;
using CurriculumProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurriculumProject.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private CurriculumContext db;
        private DepartmentRepository departmentRep;
        private FacultyRepository facultyRep;
        private SpecialityRepository specialityRep;
        private SubjectRepository subjectRep;

        private bool disposed = false;

        public EFUnitOfWork(string conectionString)
        {
            db = new CurriculumContext(conectionString);
        }

        public IRepository<Department> Departments
        {
            get
            {
                if (departmentRep == null)
                {
                    departmentRep = new DepartmentRepository(db);
                }
                return departmentRep;
            }
        }

        public IRepository<Faculty> Faculties
        {
            get
            {
                if (facultyRep == null)
                    facultyRep = new FacultyRepository(db);
                return facultyRep;
            }
        }

        public IRepository<Speciality> Specialities
        {
            get
            {
                if (specialityRep == null)
                    specialityRep = new SpecialityRepository(db);
                return specialityRep;
            }
        }


        public IRepository<Subject> Subjects
        {
            get
            {
                if (subjectRep == null)
                    subjectRep = new SubjectRepository(db);
                return subjectRep;
            }
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