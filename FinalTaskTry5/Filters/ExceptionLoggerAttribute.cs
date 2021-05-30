using FinalTaskTry5.BLL.DTO;
using FinalTaskTry5.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace FinalTaskTry5.Filters
{
    public class ExceptionLoggerAttribute : FilterAttribute, IExceptionFilter
    {
        private UserService userService = new UserService();

        public void OnException(ExceptionContext filterContext)
        {
            ExceptionLoggerDto exceptionLogger = new ExceptionLoggerDto()
            {
                ExceptionMessage = filterContext.Exception.Message,
                ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                ActionName = filterContext.RouteData.Values["action"].ToString(),
                Date = DateTime.Now,
                ApplicationUserName = filterContext.HttpContext.User.Identity.Name
            };

            userService.AddNewLog(exceptionLogger).ConfigureAwait(false);
        }
    }
}