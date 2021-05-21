namespace TaskService
{
    #region 响应
    /// <summary>
    /// Bili接口响应
    /// </summary>
    public class BiliApiResponse<T>
    {
        /// <summary>
        /// 代码
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ttl { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public T data { get; set; }
    } 
    #endregion

    #region 登录
    /// <summary>
    /// 登录信息
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isLogin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int email_verified { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string face { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public LevelInfo level_info { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int mid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int mobile_verified { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int money { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int moral { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Official official { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public OfficialVerify officialVerify { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Pendant pendant { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int scores { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string uname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int vipDueDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int vipStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int vipType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int vip_pay_type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int vip_theme_type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public VipLabel vip_label { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int vip_avatar_subscript { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string vip_nickname_color { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Wallet wallet { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string has_shop { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string shop_url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int allowance_count { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int answer_status { get; set; }
    }
    
    /// <summary>
    /// 
    /// </summary>
    public class LevelInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public int current_level { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int current_min { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int current_exp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int next_exp { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Official
    {
        /// <summary>
        /// 
        /// </summary>
        public int role { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string desc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class OfficialVerify
    {
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string desc { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Pendant
    {
        /// <summary>
        /// 
        /// </summary>
        public int pid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string image { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int expire { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string image_enhance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string image_enhance_frame { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class VipLabel
    {
        /// <summary>
        /// 
        /// </summary>
        public string path { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string label_theme { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Wallet
    {
        /// <summary>
        /// 
        /// </summary>
        public int mid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int bcoin_balance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int coupon_balance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int coupon_due_time { get; set; }
    }
    #endregion

    #region 任务
    /// <summary>
    /// 任务信息
    /// </summary>
    public class DailyTaskInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public bool Login { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public bool Watch { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long Coins { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Share { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Tel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Safe_question { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Identify_card { get; set; }
    } 
    #endregion
}
