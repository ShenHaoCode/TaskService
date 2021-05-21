using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace TaskService
{
    /// <summary>
    /// 方法时间过滤器
    /// </summary>
    public class ActionTimeAttribute : ActionFilterAttribute
    {
        private const string Key = "__action_duration__";

        /// <summary>
        /// 启动计时器
        /// </summary>
        /// <param name="actionContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            Stopwatch stopWatch = new Stopwatch();
            actionContext.Request.Properties[Key] = stopWatch;
            stopWatch.Start();
            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }

        /// <summary>
        /// 记录监控接口执行日志
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            if (!actionExecutedContext.Request.Properties.ContainsKey(Key)) { return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken); }
            Stopwatch stopWatch = actionExecutedContext.Request.Properties[Key] as Stopwatch;
            if (stopWatch != null)
            {
                stopWatch.Stop();
                string actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
                string controllerName = actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                string logMessage = string.Format("执行 {0}/{1} 耗时 {2}", controllerName, actionName, stopWatch.Elapsed);
                LogHelper.Debug(logMessage);
            }
            return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        }
    }
}
