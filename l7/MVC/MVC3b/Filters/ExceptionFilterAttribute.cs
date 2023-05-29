using System.Web.Mvc;

namespace Lab4b.Filters
{
    public class ExceptionFilterAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<p>Exception Filter executing</p>");
            filterContext.ExceptionHandled = true;
        }
    }
}