using SourceryWeb.Models;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace SourceryWeb
{
    public class MvcApplication : HttpApplication
    {
        protected async Task AsyncStart()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            await Bot.Get();
        }
        protected void Application_Start() => AsyncStart().GetAwaiter().GetResult();
    }
}
