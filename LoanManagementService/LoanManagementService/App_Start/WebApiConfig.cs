using LoanManagementService.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;

namespace LoanManagementService
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

            // Enabling cors to all
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Custom Exception Filter
            config.Filters.Add(new LoanExceptionFilter());

            // Custom Unhandled exception logic
            config.Services.Replace(typeof(IExceptionLogger), new ServiceExceptionLogger());

        }

    }
}
