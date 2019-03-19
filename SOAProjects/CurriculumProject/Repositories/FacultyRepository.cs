using CurriculumProject.Context;
using CurriculumProject.Interfaces;
using CurriculumProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CurriculumProject.Repositories
{
    public class FacultyRepository : IRepository<Faculty>
    {
        private CurriculumContext db;

        public FacultyRepository(CurriculumContext context)
        {
            db = context;
        }

        public void Create(Faculty faculty)
        {
            db.Faculties.Add(faculty);
        }

        public void Delete(int id)
        {
            Faculty faculty = db.Faculties.Find(id);
            if (faculty != null)
            {
                db.Faculties.Remove(faculty);
            }
        }

        public IEnumerable<Faculty> Find(Func<Faculty, bool> predicate)
        {
            return db.Faculties.Where(predicate).ToList();
        }

        public Faculty Get(int id)
        {
            return db.Faculties.Find(id);
        }

        public IEnumerable<Faculty> GetAll()
        {
            return db.Faculties;
                 
        }

        public void Update(Faculty faculty)
        {
            db.Entry(faculty).State = EntityState.Modified;
        }
    }
}