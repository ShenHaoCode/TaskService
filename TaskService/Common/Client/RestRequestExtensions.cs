using RestSharp;
using RestSharp.Serializers;

namespace TaskService
{
    /// <summary>
    /// 
    /// </summary>
    public class RestRequestExtensions : RestRequest
    {
        /// <summary>
        /// 使用自定义的JSON序列化类
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="method">方法</param>
        /// <param name="jsonSerializer">JSON序列化类</param>
        public RestRequestExtensions(string url, Method method, ISerializer jsonSerializer) : base(url, method)
        {
            this.JsonSerializer = jsonSerializer;
        }
    }
}
