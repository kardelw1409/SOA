using CurriculumProject.Interfaces;
using CurriculumProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CurriculumProject.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DbContext db;
        private IRepository<Faculty> facultyRep;
        private IRepository<Department> departmentRep;
        private IRepository<Speciality> specialityRep;
        private IRepository<Subject> subjectRep;

        public IRepository<Faculty> Faculties
        {
            get
            {
                if (facultyRep == null)
                {
                    facultyRep = new 
                }
            }
        }

        public IRepository<Department> Departments => throw new NotImplementedException();

        public IRepository<Speciality> Specialties => throw new NotImplementedException();

        public IRepository<Subject> Subjects => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}