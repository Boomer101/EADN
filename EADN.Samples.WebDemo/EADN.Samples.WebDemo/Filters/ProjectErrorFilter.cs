using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EADN.Samples.WebDemo.Filters
{
    public class ProjectErrorFilter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(filterContext.Exception)
            };

            filterContext.ExceptionHandled = true;
        }
    }
}