using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Midterm.Filters
{
    public class HandleNotImplementedFilter: FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var exceptionMessage = filterContext.Exception.Message;
            var stackTrace = filterContext.Exception.StackTrace;
            var controllerName = filterContext.RouteData.Values["controller"].ToString();
            var actionName = filterContext.RouteData.Values["action"].ToString();

            string Message = "Date :" + DateTime.Now.ToString() + ", Controller: " + controllerName + ", Action:" + actionName +
                             "Error Message : " + exceptionMessage
                            + Environment.NewLine + "Stack Trace : " + stackTrace;
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/Log/Log.txt"), Message);

            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error"
            };
        }
    }
}