using RestSharp.Serializers;
using ServiceStack;

namespace TaskService
{
    /// <summary>
    /// 使用ServiceStack序列化
    /// </summary>
    public class ServiceStackToJson : ISerializer
    {
        /// <summary>
        /// 
        /// </summary>
        public string DateFormat { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RootElement { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ServiceStackToJson() { this.ContentType = "application/json"; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string Serialize(object obj)
        {
            return obj.ToJson();
        }
    }
}
