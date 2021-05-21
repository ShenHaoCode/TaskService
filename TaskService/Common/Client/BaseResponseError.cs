using System.Collections.Generic;

namespace TaskService
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseResponseError
    {
        /// <summary>
        /// 
        /// </summary>
        public BaseResponseError()
        {
            Meta = new Dictionary<string, string>();
        }

        /// <summary>
        /// 
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, string> Meta { get; set; }
    }
}
