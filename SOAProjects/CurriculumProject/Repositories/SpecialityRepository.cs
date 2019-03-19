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
    public class SpecialityRepository : IRepository<Speciality>
    {
        private CurriculumContext db;

        public SpecialityRepository(CurriculumContext context)
        {
            db = context;
        }

        public void Create(Speciality speciality)
        {
            db.Specialities.Add(speciality);
        }

        public void Delete(int id)
        {
            Speciality speciality = db.Specialities.Find(id);
            if (speciality != null)
            {
                db.Specialities.Remove(speciality);
            }
        }

        public IEnumerable<Speciality> Find(Func<Speciality, bool> predicate)
        {
            return db.Specialities.Where(predicate).ToList();
        }

        public Speciality Get(int id)
        {
            return db.Specialities.Find(id);
        }

        public IEnumerable<Speciality> GetAll()
        {
            return db.Specialities;
        }

        public void Update(Speciality speciality)
        {
            db.Entry(speciality).State = EntityState.Modified;
        }
    }
}