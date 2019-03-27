using CurriculumProject.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurriculumProject.Interfaces
{
    public interface IDbFactory
    {
        DbContext Init();
    }
}
