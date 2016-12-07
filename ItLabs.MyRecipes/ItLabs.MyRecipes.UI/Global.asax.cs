using ItLabs.MyRecipes.Domain.DependencyInjection;
using ItLabs.MyRecipes.UI.Controllers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace ItLabs.MyRecipes.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            IoCConfig.RegisterDependencies();

            //var builder = new ContainerBuilder();

            //// You can register controllers all at once using assembly scanning...
            ////builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //// ...or you can register individual controlllers manually.
            //builder.RegisterType<HomeController>().InstancePerRequest();
        }
    }
}
