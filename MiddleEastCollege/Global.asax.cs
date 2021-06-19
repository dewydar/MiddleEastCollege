using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MiddleEastCollege
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.Add(typeof(DateTime), new CustomDateBinder());
            ModelBinders.Binders.Add(typeof(DateTime?), new NullableCustomDateBinder());
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["_culture"];
            if (cookie != null && cookie.Value != null)
            {
                try
                {

                    System.Threading.Thread.CurrentThread.CurrentCulture =
                        new System.Globalization.CultureInfo(cookie.Value);
                    System.Threading.Thread.CurrentThread.CurrentUICulture =
                        new System.Globalization.CultureInfo(cookie.Value);


                    CultureInfo cInf = new CultureInfo(cookie.Value);

                    cInf.DateTimeFormat.DateSeparator = "/";
                    cInf.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
                    cInf.DateTimeFormat.LongDatePattern = "dd/MM/yyyy hh:mm:ss tt";

                    System.Threading.Thread.CurrentThread.CurrentCulture = cInf;
                    System.Threading.Thread.CurrentThread.CurrentUICulture = cInf;
                }
                catch
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture =
                  new System.Globalization.CultureInfo("ar-EG");
                    System.Threading.Thread.CurrentThread.CurrentUICulture =
                        new System.Globalization.CultureInfo("ar-EG");
                }
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentCulture =
                    new System.Globalization.CultureInfo("ar-EG");
                System.Threading.Thread.CurrentThread.CurrentUICulture =
                    new System.Globalization.CultureInfo("ar-EG");
            }
        }
    }
    public class CustomDateBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext == null)
                throw new ArgumentNullException("controllerContext", "controllerContext is null.");
            if (bindingContext == null)
                throw new ArgumentNullException("bindingContext", "bindingContext is null.");

            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (value == null)
                throw new ArgumentNullException(bindingContext.ModelName);
  
            Thread.CurrentThread.CurrentCulture =
                    new System.Globalization.CultureInfo("en");
            System.Threading.Thread.CurrentThread.CurrentUICulture =
                    new System.Globalization.CultureInfo("en");
            CultureInfo cultureInf = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            cultureInf.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, value);

            try
            {
                var dates = DateTime.ParseExact(value.AttemptedValue, "yyyy-MM-dd",CultureInfo.InvariantCulture);
                //var dd=Convert.ToDateTime(value.AttemptedValue).Date;
                //var date = value.ConvertTo(typeof(DateTime), cultureInf);
                Thread.CurrentThread.CurrentCulture =
                    new System.Globalization.CultureInfo(cultureInf.ToString());
                return dates;
            }
            catch (Exception ex)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex);
                return null;
            }
        }
    }

    public class NullableCustomDateBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext == null)
                throw new ArgumentNullException("controllerContext", "controllerContext is null.");
            if (bindingContext == null)
                throw new ArgumentNullException("bindingContext", "bindingContext is null.");

            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (value == null) return null;
            if (value.AttemptedValue == "") return null;
            CultureInfo cultureInf = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            cultureInf.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";

            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, value);

            try
            {
                var dates = DateTime.ParseExact(value.AttemptedValue, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                return dates;
            }
            catch (Exception ex)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex);
                return null;
            }
        }
    }
}
