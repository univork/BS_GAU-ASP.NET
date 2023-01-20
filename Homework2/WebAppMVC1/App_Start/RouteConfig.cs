using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Homework2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    "Product",
            //    //mxolod Product Controlleris gadacememit shegvidzlia am route is gamokeneba sxvas ver gadavcemt.
            //    //gadaecema gamoshvebis tarigi romlis cifrebi ver ikneba 4ze meti da id-is numeric only.
            //    "Product/{action}/{id}/{releaseYear}",
            //    new { controller = "Product", action = "Product" },
            //    new { id = "\\d+", releaseYear = "\\d{4}" }
            //);

            //routes.MapRoute(
            //    "User",
            //    "{controller}/{action}/{name}",
            //    new { controller = "User", action = "GetUserName" }
            //);

            //routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                "Student",
                "{controller}/{action}/{id}",
                new { controller = "Student", action = "Index", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index" , id = UrlParameter.Optional }
            );
        }
    }
}
