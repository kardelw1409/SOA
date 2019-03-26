using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using CurriculumProject.App_Start;
using CurriculumProject.Context;
using CurriculumProject.Interfaces;
using CurriculumProject.Services;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace CurriculumProject
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            AreaRegistration.RegisterAllAreas();

            //Bootstrapper.Run();
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterGeneric(typeof(EntityCrudService<>))
                   .As(typeof(IEntityCrudService<>))
                   .WithParameter("dbContext", new CurriculumContext("CurriculumConnection"))
                   .InstancePerLifetimeScope();

            ILifetimeScope container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
