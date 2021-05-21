// 常见的HTTP状态码：
// 200 - 请求成功
// 301 - 资源（网页等）被永久转移到其它URL
// 404 - 请求的资源（网页等）不存在
// 500 - 内部服务器错误

using System.Collections.Generic;

namespace TaskService
{
    /// <summary>
    /// 返回类型，对象集合
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponseList<T> : IBaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public BaseResponseList()
        {
            IsOK = true;
            Status = new BaseResponseStatus();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsOK { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public string ErrorCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> MessageParams { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BaseResponseStatus Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<T> Results { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long Total { get; set; }
    }
}
