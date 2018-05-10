using System.Web.Mvc;

namespace Loja.Mvc
{
    public class LogErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext?.Exception != null)
            {
                var controller = filterContext.RouteData.Values["controller"].ToString();
                var action = filterContext.RouteData.Values["action"].ToString();
                var loggerName = $"{controller}Controller.{action}";

                log4net.LogManager.GetLogger(loggerName).Error(filterContext.Exception.Message, filterContext.Exception);

                base.OnException(filterContext);
            }
        }
    }
}