using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebDocTruyenOnline
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Search",
                url: "tim-kiem",
                defaults: new { controller = "Stories", action = "Search", id = UrlParameter.Optional },
                namespaces: new[] { "WebDocTruyenOnline.Controllers" }
            );

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Story Type",
                url: "the-loai/{metatitle}-{typeId}",
                defaults: new { controller = "Stories", action = "Type", id = UrlParameter.Optional },
                namespaces: new[] { "WebDocTruyenOnline.Controllers" }
            );

           routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Category",
                url: "danh-muc/{metatitle}-{Id}",
                defaults: new { controller = "Stories", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "WebDocTruyenOnline.Controllers" }
            );

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Read Story",
                url: "doc-truyen/{metatitle}-{storyID}-{chap}",
                defaults: new { controller = "ChapStories", action = "ReadStory", id = UrlParameter.Optional },
                namespaces: new[] { "WebDocTruyenOnline.Controllers" }
            );

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Story Detail",
                url: "truyen/{metatitle}-{id}",
                defaults: new { controller = "Stories", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "WebDocTruyenOnline.Controllers" }
            );

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Login",
                url: "dang-nhap",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
                namespaces: new[] { "WebDocTruyenOnline.Controllers" }
            );

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Register",
                url: "dang-ky",
                defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional },
                namespaces: new[] { "WebDocTruyenOnline.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"WebDocTruyenOnline.Controllers"}
            );
        }
    }
}
