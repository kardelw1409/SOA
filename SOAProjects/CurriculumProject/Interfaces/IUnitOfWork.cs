using CurriculumProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurriculumProject.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Department> Departments { get; }
        IRepository<Faculty> Faculties { get; }
        IRepository<Speciality> Specialities { get; }
        IRepository<Subject> Subjects { get; }
        void Save();
    }
}