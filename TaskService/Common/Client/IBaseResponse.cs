using System.Collections.Generic;

namespace TaskService
{
    /// <summary>
    /// 返回结果基类接口
    /// </summary>
    public interface IBaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        bool IsOK { get; set; }

        /// <summary>
        /// 
        /// </summary>

        string ErrorCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        List<string> MessageParams { get; set; }

        /// <summary>
        /// 
        /// </summary>
        BaseResponseStatus Status { get; set; }
    }
}
