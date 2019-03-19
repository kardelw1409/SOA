using CurriculumProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurriculumProject.Interfaces
{
    public interface IFacultyServices
    {
        Faculty GetFaculty(int? id);
        IEnumerable<Faculty> GetFaculties();
        void Dispose();
    }
}
