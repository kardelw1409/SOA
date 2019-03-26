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
        public CurriculumContext(string connectionString) : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        static CurriculumContext()
        {
            //Database.SetInitializer(new StoreDbInitializer());
        }

        public DbSet<Department> Departments { get; set; }  
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<CurriculumContext>
    {
        protected override void Seed(CurriculumContext db)
        {
            db.Faculties.Add(new Faculty { Name = "FMaIT" });
            db.Faculties.Add(new Faculty { Name = "BF" });
            db.Faculties.Add(new Faculty { Name = "IF" });
            db.Specialities.Add(new Speciality { FacultyId = 1, Name = "POIT", Plan = 24 });
            db.Specialities.Add(new Speciality { FacultyId = 1, Name = "POKS", Plan = 22 });
            db.Departments.Add(new Department { FacultyId = 1, Name = "CPaSP"});
            db.Departments.Add(new Department { FacultyId = 1, Name = "CIaIT" });
            db.Subjects.Add(new Subject { DepartmentId = 1, Name = "Math", IsCredit = true, IsExam = true });
            db.Subjects.Add(new Subject { DepartmentId = 2, Name = "Programming Language", IsCredit = true, IsExam = true });
            db.SaveChanges();
        }
    }
}