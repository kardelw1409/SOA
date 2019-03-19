﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurriculumProject.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsExam { get; set; }
        public bool IsCredit { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        //public virtual ICollection<Performance> Performances { get; set; }
        
        public Subject()
        {
            //Performances = new List<Performance>();
        }

    }
}