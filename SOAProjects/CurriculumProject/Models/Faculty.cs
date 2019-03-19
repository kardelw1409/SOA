using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurriculumProject.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Speciality> Specialities { get; set; }

        public Faculty()
        {
            Departments = new List<Department>();
            Specialities = new List<Speciality>();
        }
    }
}