using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace TaskService
{
    /// <summary>
    /// 全局异常过滤器
    /// </summary>
    public class GlobalExceptionAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            string controllerName = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
            string actonName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
            if (actionExecutedContext.Exception != null)
            {
                LogHelper.Error(string.Format("{0}/{1} 执行异常退出", controllerName, actonName), actionExecutedContext.Exception);
                LogHelper.Error(string.Format("{0}/{1} 异常参数：{2}", controllerName, actonName, JsonConvert.SerializeObject(actionExecutedContext.ActionContext.ActionArguments)));
            }

            string errorMessage = "";
            if (actionExecutedContext.Exception != null)
            {
                errorMessage = actionExecutedContext.Exception.Message;
                if (actionExecutedContext.Exception.InnerException != null)
                {
                    errorMessage = string.Format("{0} [{1}]", errorMessage, actionExecutedContext.Exception.InnerException.Message);
                }
            }

            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(new BaseResponse<object>() { IsOK = false, ErrorCode = "ExceptionError", Message = errorMessage, Results = null });
            base.OnException(actionExecutedContext);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            return base.OnExceptionAsync(actionExecutedContext, cancellationToken);
        }
    }
}
