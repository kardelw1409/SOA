using Autofac;
using Autofac.Integration.WebApi;
using CurriculumService.Context;
using CurriculumService.Interfaces;
using CurriculumService.Models;
using CurriculumService.Repositories;
using CurriculumService.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace CurriculumService.App_Start
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


            builder.RegisterType<CurriculumContext>()
                   .As<DbContext>()
                   .InstancePerRequest();

            builder.RegisterType<DbFactory>()
                 .As<IDbFactory>()
                 .InstancePerRequest();

            builder.RegisterGeneric(typeof(EntityCrudService<>))
                   .As(typeof(IEntityCrudService<>))
                   .InstancePerRequest();

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }
    }
}