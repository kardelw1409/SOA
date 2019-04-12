using CurriculumService.App_Start;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace CurriculumService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            Bootstrapper.Run();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
