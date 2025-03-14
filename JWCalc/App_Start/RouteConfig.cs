﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JWCalc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Criar rota amigável para a folha de contas
            //routes.MapRoute(
            //    name: "Folha de Contas",
            //    url: "FolhaContas/{ano}-{mes}/S-26",
            //    defaults: new { controller = "Donativos", action = "Index", id = UrlParameter.Optional }
            //);


            //routes.MapRoute(
            //    name: "Home",
            //    url: "Home/",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
