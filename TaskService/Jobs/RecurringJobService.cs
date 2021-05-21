using Hangfire;
using Hangfire.Console;
using Hangfire.Server;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace TaskService
{
    /// <summary>
    /// 定时任务执行
    /// </summary>
    public class RecurringJobService
    {
        #region 测试
        /// <summary>
        /// 简单任务
        /// </summary>
        /// <param name="context"></param>
        public async Task SimpleJob([FromResult]PerformContext context)
        {
            context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} SimpleJob Running ...");
            var progressBar = context.WriteProgressBar();
            foreach (var i in Enumerable.Range(1, 50).ToList().WithProgress(progressBar))
            {
                System.Threading.Thread.Sleep(1000);
            }
            await Task.Yield();
        }
        #endregion

        #region 哔哩哔哩
        /// <summary>
        /// 签到任务
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task SignInJob([FromResult]PerformContext context)
        {
            context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} SignInJob Running ...");
            ResultModel<bool> tResult = BilibiliClient.SignInTask();
            if (tResult.IsOK) { context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} SignInJob Run successfully"); }
            await Task.Yield();
        } 
        #endregion
    }
}
