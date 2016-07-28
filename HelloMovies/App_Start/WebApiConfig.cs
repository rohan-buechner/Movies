using System.Linq;
using System.Web.Http;

namespace HelloMovies
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // force JSON only results
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(
                 config.Formatters
                       .XmlFormatter
                       .SupportedMediaTypes
                       .FirstOrDefault(o => o.MediaType == "application/xml"));
        }
    }
}
