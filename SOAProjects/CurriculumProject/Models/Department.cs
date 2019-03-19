using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurriculumProject.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }

        public Department()
        {
            Subjects = new List<Subject>();
        }
    }
}