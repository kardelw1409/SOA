using StudentsProject.Context;
using StudentsProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentsProject.Repositories
{
    public class DbFactory : IDbFactory
    {
        DbContext dbContext;

        public DbContext Init()
        {
            return dbContext ?? (dbContext = new StudentsContext("StudentsConnection"));
        }
    }
}