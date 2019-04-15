using CurriculumService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CurriculumService.Context
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

    public class StoreDbInitializer : DropCreateDatabaseAlways<CurriculumContext>
    {
        protected override void Seed(CurriculumContext db)
        {
            db.Faculties.Add(new Faculty { Name = "FMaIT" });
            db.Faculties.Add(new Faculty { Name = "BF" });
            db.Faculties.Add(new Faculty { Name = "IF" });
            db.Specialities.Add(new Speciality { Name = "POIT", Plan = 24, FacultyId = 1 });
            db.Specialities.Add(new Speciality { Name = "POKS", Plan = 22, FacultyId = 1});
            //db.Departments.Add(new Department { Name = "CPaSP", FacultyId = 1});
            //db.Departments.Add(new Department { Name = "CIaIT", FacultyId = 1});
            //db.Subjects.Add(new Subject {  Name = "Math",  IsExam = true , IsCredit = true, DepartmentId = 1});
            //db.Subjects.Add(new Subject {  Name = "Programming Language", IsExam = true,  IsCredit = true, DepartmentId = 2});
            db.SaveChanges();
        }
    }
}