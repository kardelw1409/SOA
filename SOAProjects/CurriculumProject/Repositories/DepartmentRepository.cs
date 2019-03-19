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
    public class DepartmentRepository : IRepository<Department>
    {
        private CurriculumContext db;

        public DepartmentRepository(CurriculumContext context)
        {
            db = context;
        }

        public void Create(Department department)
        {
            db.Departments.Add(department);
        }

        public void Delete(int id)
        {
            Department department = db.Departments.Find(id);
            if (department != null)
            {
                db.Departments.Remove(department);
            }
        }

        public IEnumerable<Department> Find(Func<Department, bool> predicate)
        {
            return db.Departments.Where(predicate).ToList();
        }

        public Department Get(int id)
        {
            return db.Departments.Find(id);
        }

        public IEnumerable<Department> GetAll()
        {
            return db.Departments;
        }

        public void Update(Department department)
        {
            db.Entry(department).State = EntityState.Modified;
        }
    }
}