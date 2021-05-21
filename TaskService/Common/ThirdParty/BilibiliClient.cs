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
        public const string Cookie = "_uuid=598E0EEE-8F03-8543-BBA2-CD445DA17E2973131infoc; buvid3=953749EE-3B3D-43E6-A0A7-9644BDD5624553920infoc; sid=54oawjqi; stardustvideo=1; LIVE_BUVID=AUTO3715776353235143; rpdid=|(J|)YYYkYJk0J'ul~~YJlJJ); blackside_state=1; CURRENT_FNVAL=80; DedeUserID=330500587; DedeUserID__ckMd5=e88b37dd8f3741c0; SESSDATA=8f648384%2C1618759881%2Cfe441*a1; bili_jct=eec2481d1146b88bad04335e6b802f85; PVID=1; bp_t_offset_330500587=466799663029748234; fingerprint3=84457829a1f5442a01efdadc42095871; fingerprint=9bddf90bdccc79f15795cc9d12c805b4; buivd_fp=953749EE-3B3D-43E6-A0A7-9644BDD5624553920infoc; buvid_fp_plain=953749EE-3B3D-43E6-A0A7-9644BDD5624553920infoc; fingerprint_s=2f9e72c7bc2bae6adb288139b586b2b1; bp_video_offset_330500587=470429842403918208; bfe_id=61a513175dc1ae8854a560f6b82b37af";

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
