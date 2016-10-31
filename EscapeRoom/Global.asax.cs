using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace EscapeRoom
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            WebMatrix.WebData.WebSecurity.InitializeDatabaseConnection("EscapeRoom", "User", "Id", "Email", true);

            if (!Roles.RoleExists("Administrator"))
                Roles.CreateRole("Administrator");
            
            //Roles.AddUserToRole("briandfrederick+21@gmail.com", "Administrator");
        }
    }
}
