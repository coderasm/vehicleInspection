using System.Web.Http;
using Inspection.DataAccess;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;

namespace Inspection
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<FlooredCarFlatRepository, FlooredCarFlatDAO>(new HierarchicalLifetimeManager());
            container.RegisterType<BaseRepository<FlooredCarFlatRepository>, Repository<FlooredCarFlatRepository>>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
