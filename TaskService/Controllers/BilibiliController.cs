using Hangfire;
using System;
using System.Web.Http;

namespace TaskService.Controllers
{
    /// <summary>
    /// 哔哩哔哩 控制器
    /// </summary>
    public class BilibiliController : ApiController
    {
        /// <summary>
        /// 创建签到任务
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<bool> CreateSignInJob()
        {
            BaseResponse<bool> sResponse = new BaseResponse<bool>();
            RecurringJob.AddOrUpdate<RecurringJobService>("SignInJob", X => X.SignInJob(null), Cron.Daily(9), TimeZoneInfo.Local);
            sResponse.IsOK = true; sResponse.ErrorCode = CommonErrorCode.Success; sResponse.Message = "成功"; return sResponse;
        }

        /// <summary>
        /// 执行签到任务
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse<bool> ExecSignInJob()
        {
            BaseResponse<bool> sResponse = new BaseResponse<bool>();
            ResultModel<bool> tResult = BilibiliClient.SignInTask();
            if (tResult.IsOK) { sResponse.IsOK = true; sResponse.ErrorCode = CommonErrorCode.Success; sResponse.Message = "成功"; sResponse.Results = true; }
            if (!tResult.IsOK) { sResponse.IsOK = false; sResponse.ErrorCode = tResult.ErrorCode; sResponse.Message = tResult.Message; sResponse.Results = false; }
            return sResponse;
        }
    }
}
