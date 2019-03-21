using CurriculumProject.Models;
using CurriculumProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurriculumProject.Interfaces
{
    public interface IUnitOfWork<TEntity> : IDisposable
        where TEntity : Entity
    {
        IRepository<TEntity> Repository { get; }
        /*IRepository<Department> Departments { get; }
        IRepository<Faculty> Faculties { get; }
        IRepository<Speciality> Specialities { get; }
        IRepository<Subject> Subjects { get; }*/
        void Save();
    }
}