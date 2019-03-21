using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurriculumProject.Models
{
    public class Speciality : Entity
    {
        public string Name { get; set; }
        public int Plan { get; set; }

        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
        //TO DO
        //public virtual ICollection<Group> Groups { get; set; }
        //public virtual ICollection<Entrant> Entrants { get; set; }

        public Speciality()
        {
            //TO DO
            //Entrants = new List<Entrant>();
            //Groups = new List<Group>();
        }
    }
}