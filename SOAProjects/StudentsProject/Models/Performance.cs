using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsProject.Models
{
    public class Performance : Entity
    {
        public byte IsDone { get; set; }

        public int SubjectId { get; set; }
        public decimal StudentId { get; set; }


        public Performance()
        {
            
        }

    }
}