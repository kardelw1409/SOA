using CurriculumProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurriculumProject.Interfaces
{
    interface IUnitOfWork
    {
        IRepository<Department> Departments { get; set; }
        IRepository<Faculty> Faculties { get; set; }
        IRepository<Speciality> Specialities { get; set; }
        IRepository<Subject> Subjects { get; set; }
    }
}