using Autofac;
using Autofac.Integration.WebApi;
using CurriculumProject.Context;
using CurriculumProject.Interfaces;
using CurriculumProject.Models;
using CurriculumProject.Repositories;
using CurriculumProject.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace CurriculumProject.App_Start
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterGeneric(typeof(EntityCrudService<>))
                   .As(typeof(IEntityCrudService<>))
                   .WithParameter("dbContext", new CurriculumContext("CurriculumConnection"))
                   .InstancePerLifetimeScope();

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }
    }
}