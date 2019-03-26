using CurriculumProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurriculumProject.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        IRepository<Faculty> Faculties { get; }
        IRepository<Department> Departments { get; }
        IRepository<Speciality> Specialties { get; }
        IRepository<Subject> Subjects { get; }
        void Save();
    }
}
