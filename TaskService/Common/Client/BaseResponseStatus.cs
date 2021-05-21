using System.Collections.Generic;

namespace TaskService
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseResponseStatus
    {
        /// <summary>
        /// 
        /// </summary>
        public BaseResponseStatus()
        {
            Meta = new Dictionary<string, string>();
            Errors = new List<BaseResponseError>();
        }

        /// <summary>
        /// 
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string StackTrace { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, string> Meta { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<BaseResponseError> Errors { get; set; }
    }
}
