using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EADN.Samples.WebDemo.Filters
{
    public class MyActionFilter : ActionFilterAttribute
    {
        // Wird erreicht durch [MyActionFilter] in QuizController -> Alle Methoden
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}