using CurriculumProject.Context;
using CurriculumProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CurriculumProject.Repositories
{
    public class DbFactory : IDbFactory
    {
        DbContext dbContext;

        public DbContext Init()
        {
            return dbContext ?? (dbContext = new CurriculumContext("CurriculumConnection"));
        }
    }
}