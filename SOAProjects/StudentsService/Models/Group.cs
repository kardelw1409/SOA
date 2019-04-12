using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsService.Models
{
    public class Group : Entity
    {
        public string Name { get; set; }
        public int Course { get; set; }
        public int SpecialityId { get; set; }

    }
}