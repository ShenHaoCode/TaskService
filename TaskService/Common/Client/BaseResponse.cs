using System.Collections.Generic;

namespace TaskService
{
    /// <summary>
    /// 返回类型，单个对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponse<T> : IBaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public BaseResponse()
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
        public T Results { get; set; }
    }
}
