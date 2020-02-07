using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace demo1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapMvcAttributeRoutes();
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*botdetect}", new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                name: "Blog",
                url: "bai-viet",
                defaults: new { controller = "Blog", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "demo1.Controllers" }
            );

            routes.MapRoute(
                name: "BlogCategory",
                url: "danh-muc-bai-viet/{ID}",
                defaults: new { controller = "Blog", action = "IndexByCategory", id = UrlParameter.Optional },
                namespaces: new[] { "demo1.Controllers" }
            );

            routes.MapRoute(
               name: "Service",
               url: "dich-vu",
               defaults: new { controller = "Service", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "demo1.Controllers" }
            );
            
            routes.MapRoute(
               name: "BlogNutrition",
               url: "che-do-dinh-duong",
               defaults: new { controller = "BlogNutrition", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "demo1.Controllers" }
            );
            routes.MapRoute(
               name: "Contact",
               url: "ket-noi",
               defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "demo1.Controllers" }
            );


            routes.MapRoute(
                name: "PracticeDemo",
                url: "dang-ky-tap-thu",
                defaults: new { controller = "PracticeDemo", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "demo1.Controllers" }
            );

            routes.MapRoute(
                name: "WorkoutSchedule",
                url: "lich-tap",
                defaults: new { controller = "WorkoutSchedule", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "demo1.Controllers" }
            );

            
            routes.MapRoute(
               name: "HomeLogOut",
               url: "dang-xuat",
               defaults: new { controller = "Home", action = "LogOut", id = UrlParameter.Optional },
               namespaces: new[] { "demo1.Controllers" }
            ); 

            routes.MapRoute(
               name: "HomeLogin",
               url: "dang-nhap",
               defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional },
               namespaces: new[] { "demo1.Controllers" }
            );

            routes.MapRoute(
               name: "HomeSignIn",
               url: "dang-ky",
               defaults: new { controller = "Home", action = "SignIn", id = UrlParameter.Optional },
               namespaces: new[] { "demo1.Controllers" }
            );
            routes.MapRoute(
               name: "HomeAccount",
               url: "tai-khoan",
               defaults: new { controller = "Home", action = "Account", id = UrlParameter.Optional },
               namespaces: new[] { "demo1.Controllers" }
            );

            routes.MapRoute(
               name: "BlogDetail",
               url: "chi-tiet-bai-viet/{ID}",
               defaults: new { controller = "Blog", action = "Detail", id = UrlParameter.Optional },
               namespaces: new[] { "demo1.Controllers" }
            );

            routes.MapRoute(
               name: "Home",
               url: "trang-chu",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "demo1.Controllers" }
            );

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "demo1.Controllers" }
            );

        }
    }
}
