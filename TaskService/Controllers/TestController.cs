using Hangfire;
using System;
using System.Web.Http;

namespace TaskService.Controllers
{
    /// <summary>
    /// 测试 控制器
    /// </summary>
    public class TestController : ApiController
    {
        /// <summary>
        /// 创建简单任务
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<bool> CreateSimpleJob()
        {
            BaseResponse<bool> sResponse = new BaseResponse<bool>();
            RecurringJob.AddOrUpdate<RecurringJobService>("SimpleJob", X => X.SimpleJob(null), Cron.Daily(), TimeZoneInfo.Local);
            sResponse.IsOK = true; sResponse.ErrorCode = CommonErrorCode.Success; sResponse.Message = "成功"; return sResponse;
        }
    }
}
