using StudentsProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentsProject.Context
{
    public class StudentsContext : DbContext
    {
        public StudentsContext(string connectionString) : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        static StudentsContext()
        {
            Database.SetInitializer(new StoreDbInitializer());
        }

        public DbSet<Student> Students { get; set; }  
        public DbSet<Group> Groups { get; set; }
        public DbSet<Performance> Performances { get; set; }
    }

    public class StoreDbInitializer : DropCreateDatabaseAlways<StudentsContext>
    {
        protected override void Seed(StudentsContext db)
        {
            db.Students.Add(new Student { Id = 1, Course = 1, Enrolled = new DateTime(2015, 7, 20), GroupId = 1, RoomId = 212  });
            db.Students.Add(new Student { Id = 2, Course = 3, Enrolled = new DateTime(2016, 7, 20), GroupId = 3, RoomId = 414 });
            db.Groups.Add(new Group { Id = 1, Name = "FortyFour", Course = 4, SpecialityId = 4 });
            db.Groups.Add(new Group { Id = 2, Name = "TwentyOne", Course = 2, SpecialityId = 1 });
            db.Performances.Add(new Performance { Id = 1, IsDone = 1, StudentId = 1, SubjectId = 1 });

            db.SaveChanges();
        }
    }
}