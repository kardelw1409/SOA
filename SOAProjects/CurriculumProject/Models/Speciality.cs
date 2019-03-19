using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurriculumProject.Models
{
    public class Speciality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Plan { get; set; }

        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
        //public virtual ICollection<Group> Groups { get; set; }
        //public virtual ICollection<Entrant> Entrants { get; set; }

        public Speciality()
        {
            //Entrants = new List<Entrant>();
            //Groups = new List<Group>();
        }
    }
}