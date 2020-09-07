using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace _2Share
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            config.EnableCors();
            // Rutas de API web
            config.MapHttpAttributeRoutes();
            

            config.Formatters.JsonFormatter
                .SerializerSettings
                .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional, action = "GroceryList" }
            );
        }
    }
}
