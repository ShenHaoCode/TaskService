using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace TaskService
{
    /// <summary>
    /// 哔哩哔哩客户端
    /// </summary>
    public class BilibiliClient
    {
        /// <summary>
        /// UserAgent
        /// </summary>
        public const string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.104 Safari/537.36";

        /// <summary>
        /// Cookie
        /// </summary>
        public const string Cookie = "";

        /// <summary>
        /// 签到任务
        /// </summary>
        /// <returns></returns>
        public static ResultModel<bool> SignInTask()
        {
            ResultModel<bool> tResult = new ResultModel<bool>();
            BiliApiResponse<UserInfo> loginResult = Login();
            if (loginResult.code != 0 || !loginResult.data.isLogin) { tResult.IsOK = false; tResult.ErrorCode = ""; tResult.Message = "登陆失败"; return tResult; }
            BiliApiResponse<DailyTaskInfo> taskResult = TaskReward();

            tResult.IsOK = true; tResult.ErrorCode = ""; tResult.Message = "任务完成"; return tResult;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public static BiliApiResponse<UserInfo> Login()
        {
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.CreateHttp("https://api.bilibili.com/x/web-interface/nav");
                webRequest.Method = "GET";
                webRequest.Referer = "https://www.bilibili.com/";
                webRequest.Accept = "application/json, text/plain, */*";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.UserAgent = UserAgent;
                webRequest.Headers.Add("charset", "UTF-8");
                webRequest.Headers.Add("Cookie", Cookie);

                using (WebResponse webResponse = webRequest.GetResponse())
                {
                    StreamReader sr = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8);
                    string content = sr.ReadToEnd().ToString();
                    BiliApiResponse<UserInfo> lResult = JsonConvert.DeserializeObject<BiliApiResponse<UserInfo>>(content);
                    return lResult;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("获取登录信息错误", ex);
                return null;
            }
        }

        /// <summary>
        /// 获取每日任务
        /// </summary>
        /// <returns></returns>
        public static BiliApiResponse<DailyTaskInfo> TaskReward()
        {
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.CreateHttp("https://api.bilibili.com/x/member/web/exp/reward");
                webRequest.Method = "GET";
                webRequest.Referer = "https://www.bilibili.com/";
                webRequest.Accept = "application/json, text/plain, */*";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.UserAgent = UserAgent;
                webRequest.Headers.Add("charset", "UTF-8");
                webRequest.Headers.Add("Cookie", Cookie);

                using (WebResponse webResponse = webRequest.GetResponse())
                {
                    StreamReader sr = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8);
                    string content = sr.ReadToEnd().ToString();
                    BiliApiResponse<DailyTaskInfo> lResult = JsonConvert.DeserializeObject<BiliApiResponse<DailyTaskInfo>>(content);
                    return lResult;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("获取登录信息错误", ex);
                return null;
            }
        }
    }
}
