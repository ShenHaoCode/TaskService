using RestSharp;
using System;
using System.Collections.Generic;

namespace TaskService
{
    /// <summary>
    /// 项目http请求操作类，已转换成BaseResponse类
    /// </summary>
    public class BaseClientHelper : ClientHelper
    {
        #region 构造函数
        /// <summary>
        /// 
        /// </summary>
        public BaseClientHelper() : this("")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl"></param>
        public BaseClientHelper(string baseUrl) : base(baseUrl)
        {
            this.Client = new RestClient(baseUrl);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="timeOut">用于此客户端实例发出的请求的超时时间（以毫秒为单位） </param>
        public BaseClientHelper(string baseUrl, int timeOut) : base(baseUrl, timeOut)
        {
            this.Client = new RestClient(baseUrl);
            this.Client.Timeout = timeOut;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl"></param>
        public BaseClientHelper(Uri baseUrl) : base(baseUrl)
        {
            this.Client = new RestClient(baseUrl);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="timeOut">用于此客户端实例发出的请求的超时时间（以毫秒为单位） </param>
        public BaseClientHelper(Uri baseUrl, int timeOut) : base(baseUrl, timeOut)
        {
            this.Client = new RestClient(baseUrl);
            this.Client.Timeout = timeOut;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public BaseResponse<T> ExecuteSingle<T>(string url, Method method, object paramObj = null, IDictionary<string, string> headerObj = null) where T : new()
        {
            var request = new RestRequestExtensions(url, method, new NewtonsoftJsonSerializer());

            RestRequestWithParam(request, method, paramObj);
            RestRequestWithHeader(request, headerObj);

            IRestResponse<BaseResponse<T>> response = this.Client.Execute<BaseResponse<T>>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                if (response.Data == null) { response.Data = new BaseResponse<T>(); }
                response.Data.IsOK = false;
                response.Data.Message = response.ErrorMessage;
            }

            return response.Data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public BaseResponse<T> ExecuteGetSingle<T>(string url, object paramObj = null, IDictionary<string, string> headerObj = null) where T : new()
        {
            return this.ExecuteSingle<T>(url, Method.GET, paramObj, headerObj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public BaseResponse<T> ExecutePostSingle<T>(string url, object paramObj = null, IDictionary<string, string> headerObj = null) where T : new()
        {
            return this.ExecuteSingle<T>(url, Method.POST, paramObj, headerObj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public BaseResponse<T> ExecutePutSingle<T>(string url, object paramObj = null, IDictionary<string, string> headerObj = null) where T : new()
        {
            return this.ExecuteSingle<T>(url, Method.PUT, paramObj, headerObj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public BaseResponse<T> ExecuteDeleteSingle<T>(string url, object paramObj = null, IDictionary<string, string> headerObj = null) where T : new()
        {
            return this.ExecuteSingle<T>(url, Method.DELETE, paramObj, headerObj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public BaseResponseList<T> ExecuteList<T>(string url, Method method, object paramObj = null, IDictionary<string, string> headerObj = null) where T : new()
        {
            var request = new RestRequestExtensions(url, method, new NewtonsoftJsonSerializer());

            RestRequestWithParam(request, method, paramObj);
            RestRequestWithHeader(request, headerObj);

            IRestResponse<BaseResponseList<T>> response = this.Client.Execute<BaseResponseList<T>>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                if (response.Data == null) { response.Data = new BaseResponseList<T>(); }
                response.Data.IsOK = false;
                response.Data.Message = response.ErrorMessage;
            }

            return response.Data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public BaseResponseList<T> ExecuteGetList<T>(string url, object paramObj = null, IDictionary<string, string> headerObj = null) where T : new()
        {
            return this.ExecuteList<T>(url, Method.GET, paramObj, headerObj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public BaseResponseList<T> ExecutePostList<T>(string url, object paramObj = null, IDictionary<string, string> headerObj = null) where T : new()
        {
            return this.ExecuteList<T>(url, Method.POST, paramObj, headerObj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public BaseResponseList<T> ExecutePutList<T>(string url, object paramObj = null, IDictionary<string, string> headerObj = null) where T : new()
        {
            return this.ExecuteList<T>(url, Method.PUT, paramObj, headerObj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public BaseResponseList<T> ExecuteDeleteList<T>(string url, object paramObj = null, IDictionary<string, string> headerObj = null) where T : new()
        {
            return this.ExecuteList<T>(url, Method.DELETE, paramObj, headerObj);
        }
    }
}
