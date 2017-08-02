using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookstoreApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapMvcAttributeRoutes();

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            /*
            routes.MapRoute( //to create new routing rule
                name: "BooksByReleaseDate",
                url: "books/ByReleaseDate/{year}/{month}",
                defaults: new { controller = "Books", action = "ByReleaseDate"}
            );
            */


            routes.MapRoute( // default routing rule
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
