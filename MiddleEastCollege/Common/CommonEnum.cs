using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiddleEastCollege.Common
{
    public class CommonEnum
    {
        public enum ToastType
        {
            error,
            info,
            success,
            warning
        }
        public enum CurrentLang
        {
            FirstLang = 1,
            ScoundLang = 2
        };
    }
}