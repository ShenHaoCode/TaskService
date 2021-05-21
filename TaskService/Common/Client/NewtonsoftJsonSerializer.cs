using RestSharp.Serializers;
using ServiceStack;

namespace TaskService
{
    /// <summary>
    /// 使用Newtonsoft.Json序列化
    /// </summary>
    public class NewtonsoftJsonSerializer : ISerializer
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
        public NewtonsoftJsonSerializer() { this.ContentType = "application/json";  }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string Serialize(object obj)
        {
            //return JsonConvert.SerializeObject(obj);
            return obj.ToJson();
        }
    }
}
