using AndiQuiz.Server.Common.Constants;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AndiQuiz.Server.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //AutoMapperConfig.RegisterMappings(Assembly.Load(GlobalConstants.WebApiAssemblyName));
            DatabaseConfig.Initialize();
            //AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
