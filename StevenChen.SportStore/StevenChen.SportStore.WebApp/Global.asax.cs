using StevenChen.SportStore.Domain.Entities;
using StevenChen.SportStore.WebApp;
using StevenChen.SportStore.WebApp.Infrastructure.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StevenChen.SportStore.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            IocConfig.Register();
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
