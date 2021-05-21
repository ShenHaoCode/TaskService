using Newtonsoft.Json;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace TaskService
{
    /// <summary>
    /// 方法日志过滤器
    /// </summary>
    public class ActionLogAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string controllerName = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = actionContext.ActionDescriptor.ActionName;
            LogHelper.Info(string.Format("{0}/{1} 进入执行：{2}", controllerName, actionName, JsonConvert.SerializeObject(actionContext.ActionArguments)));
            base.OnActionExecuting(actionContext);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            string controllerName = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
            string actonName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
            if (actionExecutedContext.Exception == null)
            {
                LogHelper.Info(string.Format("{0}/{1} 执行成功退出：{2}", controllerName, actonName, JsonConvert.SerializeObject(actionExecutedContext.ActionContext.ActionArguments)));
                LogHelper.Info(string.Format("{0}/{1} 响应：{2}", controllerName, actonName, actionExecutedContext.Response.Content.ReadAsStringAsync().Result));
            }
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
