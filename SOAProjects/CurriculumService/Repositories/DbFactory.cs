using CurriculumService.Context;
using CurriculumService.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CurriculumService.Repositories
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