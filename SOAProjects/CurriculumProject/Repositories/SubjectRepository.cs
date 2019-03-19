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
    public class SubjectRepository : IRepository<Subject>
    {
        private CurriculumContext db;

        public SubjectRepository(CurriculumContext context)
        {
            db = context;
        }

        public void Create(Subject subject)
        {
            db.Subjects.Add(subject);
        }

        public void Delete(int id)
        {
            Subject subject = db.Subjects.Find(id);
            if (subject != null)
            {
                db.Subjects.Remove(subject);
            }
        }

        public IEnumerable<Subject> Find(Func<Subject, bool> predicate)
        {
            return db.Subjects.Where(predicate).ToList();
        }

        public Subject Get(int id)
        {
            return db.Subjects.Find(id);
        }

        public IEnumerable<Subject> GetAll()
        {
            return db.Subjects;
        }

        public void Update(Subject subject)
        {
            db.Entry(subject).State = EntityState.Modified;
        }
    }
}