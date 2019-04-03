using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsProject.Models
{
    public class Student : Entity
    {
        public int Course { get; set; }
        public DateTime Enrolled { get; set; }

        public int GroupId { get; set; }
        public decimal RoomId { get; set; }

    }
}




