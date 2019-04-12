using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsService.Models
{
    public class Speciality : Entity
    {
        public string Name { get; set; }
        public int Plan { get; set; }
        public int FacultyId { get; set; }

    }
}