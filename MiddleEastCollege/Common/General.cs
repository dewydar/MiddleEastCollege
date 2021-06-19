using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiddleEastCollege.Common
{
    public class General
    {
        public static string BuildToastMessage(string title, string message, CommonEnum.ToastType toastType = CommonEnum.ToastType.info)
        {
            string toastrmessage = "toastr['" + toastType + "'](\"" + message + "\", '" + title + "');";
            return toastrmessage;
        }
        public static int CurrentLang
        {
            get
            {
                if (HttpContext.Current.Session["CurrentLang"] == null)
                {

                    return Convert.ToInt32(CommonEnum.CurrentLang.ScoundLang.ToString());
                }
                else
                    return (int)HttpContext.Current.Session["CurrentLang"];
            }
            set
            {
                HttpContext.Current.Session["CurrentLang"] = value;
            }
        }
        
    }
}