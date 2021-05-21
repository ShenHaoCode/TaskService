namespace TaskService
{
    /// <summary>
    /// 结果
    /// </summary>
    public class ResultModel<T>
    {
        #region 构造函数
        /// <summary>
        /// 结果
        /// </summary>
        public ResultModel()
        {
            this.IsOK = false;
            this.Message = string.Empty;
        }

        /// <summary>
        /// 结果
        /// </summary>
        /// <param name="IsOK">是否成功</param>
        /// <param name="Message">信息</param>
        /// <param name="Result">结果</param>
        public ResultModel(bool IsOK, string Message, T Result)
        {
            this.IsOK = IsOK;
            this.Message = Message;
            this.Result = Result;
        }

        /// <summary>
        /// 结果
        /// </summary>
        /// <param name="IsOK">是否成功</param>
        /// <param name="ErrorCode">错误编码</param>
        /// <param name="Message">信息</param>
        /// <param name="Result">结果</param>
        public ResultModel(bool IsOK, string ErrorCode, string Message, T Result)
        {
            this.IsOK = IsOK;
            this.ErrorCode = ErrorCode;
            this.Message = Message;
            this.Result = Result;
        }
        #endregion

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsOK { get; set; }

        /// <summary>
        /// 错误编码
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        public T Result { get; set; }
    }
}
