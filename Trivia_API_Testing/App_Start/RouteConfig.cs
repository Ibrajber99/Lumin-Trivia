using System.Web.Mvc;
using System.Web.Routing;

namespace Trivia_API_Testing
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Trivia", action = "GetCatagories",
                id = UrlParameter.Optional }
            );
        }
    }
}
