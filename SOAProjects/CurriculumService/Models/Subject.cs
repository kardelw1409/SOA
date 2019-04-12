using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurriculumService.Models
{
    public class Subject : Entity
    {
        public string Name { get; set; }
        public bool IsExam { get; set; }
        public bool IsCredit { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        //TO DO
        //public virtual ICollection<Performance> Performances { get; set; }
        
        public Subject()
        {
            //TO DO
            //Performances = new List<Performance>();
        }

    }
}