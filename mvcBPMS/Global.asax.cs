using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using mvcBPMS.Models.Entities;
using mvcBPMS.Infrastructure.Binders;

namespace mvcBPMS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //手工添加
            ModelBinders.Binders.Add(typeof(ProjectCart), new ProjectCartModelBinder());

            //手工添加
            ModelBinders.Binders.Add(typeof(StaffCart), new StaffCartModelBinder());
        }
    }
}
