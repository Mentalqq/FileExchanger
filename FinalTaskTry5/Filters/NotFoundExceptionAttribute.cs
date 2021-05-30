using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FinalTaskTry5.Filters
{
    public class NotFoundExceptionAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && filterContext.Exception is Exception)
            {
                filterContext.Result = new RedirectResult("~/Error/NotFound");
                filterContext.ExceptionHandled = true;
            }
        }
    }
}
