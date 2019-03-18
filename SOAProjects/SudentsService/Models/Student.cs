using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SudentsService.Models
{
    public class Student
    {
        [Key]
        public int RegId { get; set; }

        public int Course { get; set; }

        public DateTime Enrolled { get; set; }

        public int GroupID { get; set; }

        public int RoomId { get; set; }
    }
}