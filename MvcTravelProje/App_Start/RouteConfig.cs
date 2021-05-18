using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcTravelProje
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "İletişim",
                url: "iletisim",
                defaults: new { controller = "Iletisim", action = "Index" }
            );

            routes.MapRoute(
                name: "Anasayfa",
                url: "anasayfa",
                defaults: new { controller = "Default", action = "Index" }
            );

            routes.MapRoute(
                name: "Hakkımızda",
                url: "hakkimizda",
                defaults: new { controller = "About", action = "Index" }
            );

            routes.MapRoute(
                name: "Blog",
                url: "blog",
                defaults: new { controller = "Blog", action = "Index"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
