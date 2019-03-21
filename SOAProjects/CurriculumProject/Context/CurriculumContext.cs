using CurriculumProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CurriculumProject.Context
{
    public class CurriculumContext : DbContext
    {
        public CurriculumContext(string conectionString) : base(conectionString)
        {

        }

        public DbSet<Department> Departments { get; set; }  
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}