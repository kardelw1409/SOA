using CurriculumProject.Interfaces;
using CurriculumProject.Models;
using CurriculumProject.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CurriculumProject.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private DbContext dbContext;
        public ServiceModule(DbContext context)
        {
            dbContext = context;
        }
        public override void Load()
        {
            Bind<IUnitOfWork<Faculty>>().To<EFUnitOfWork<Faculty>>().WithConstructorArgument(dbContext);
        }
    }
}