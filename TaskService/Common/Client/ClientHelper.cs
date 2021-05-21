using RestSharp;
using System;
using System.Collections.Generic;

namespace TaskService
{
    /// <summary>
    /// Http请求操作类
    /// </summary>
    public class ClientHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public RestClient Client { get; set; }

        #region 构造函数
        /// <summary>
        /// 
        /// </summary>
        public ClientHelper() : this("")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl"></param>
        public ClientHelper(string baseUrl)
        {
            this.Client = new RestClient(baseUrl);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="timeOut"></param>
        public ClientHelper(string baseUrl, int timeOut)
        {
            this.Client = new RestClient(baseUrl);
            this.Client.Timeout = timeOut;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl"></param>
        public ClientHelper(Uri baseUrl)
        {
            this.Client = new RestClient(baseUrl);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="timeOut"></param>
        public ClientHelper(Uri baseUrl, int timeOut)
        {
            this.Client = new RestClient(baseUrl);
            this.Client.Timeout = timeOut;
        }
        #endregion

        #region 执行
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual IRestResponse Execute(IRestRequest request)
        {
            return this.Client.Execute(request);
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual IRestResponse<T> Execute<T>(IRestRequest request) where T : new()
        {
            return this.Client.Execute<T>(request);
        }

        /// <summary>
        /// 异步执行
        /// </summary>
        /// <param name="request"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public virtual RestRequestAsyncHandle ExecuteAsync(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback)
        {
            return this.Client.ExecuteAsync(request, callback);
        }

        /// <summary>
        /// 异步执行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public virtual RestRequestAsyncHandle ExecuteAsync<T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback)
        {
            return this.Client.ExecuteAsync<T>(request, callback);
        }
        #endregion

        #region 执行
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="method"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public virtual IRestResponse Execute(string resource, Method method, object paramObj = null, IDictionary<string, string> headerObj = null)
        {
            RestRequest request = new RestRequestExtensions(resource, method, new ServiceStackToJson());

            RestRequestWithParam(request, method, paramObj);
            RestRequestWithHeader(request, headerObj);

            return this.Client.Execute(request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public virtual IRestResponse ExecuteGet(string resource, object paramObj = null, IDictionary<string, string> headerObj = null)
        {
            return this.Execute(resource, Method.GET, paramObj, headerObj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public virtual IRestResponse ExecutePost(string resource, object paramObj = null, IDictionary<string, string> headerObj = null)
        {
            return this.Execute(resource, Method.POST, paramObj, headerObj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public virtual IRestResponse ExecutePut(string resource, object paramObj = null, IDictionary<string, string> headerObj = null)
        {
            return this.Execute(resource, Method.PUT, paramObj, headerObj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public virtual IRestResponse ExecuteDelete(string resource, object paramObj = null, IDictionary<string, string> headerObj = null)
        {
            return this.Execute(resource, Method.DELETE, paramObj, headerObj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <param name="method"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public virtual IRestResponse<T> Execute<T>(string resource, Method method, object paramObj = null, IDictionary<string, string> headerObj = null) where T : new()
        {
            RestRequest request = new RestRequestExtensions(resource, method, new ServiceStackToJson());

            RestRequestWithParam(request, method, paramObj);
            RestRequestWithHeader(request, headerObj);

            return this.Client.Execute<T>(request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public virtual IRestResponse<T> ExecuteGet<T>(string resource, object paramObj = null, IDictionary<string, string> headerObj = null) where T : new()
        {
            return this.Execute<T>(resource, Method.GET, paramObj, headerObj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public virtual IRestResponse<T> ExecutePost<T>(string resource, object paramObj = null, IDictionary<string, string> headerObj = null) where T : new()
        {
            return this.Execute<T>(resource, Method.POST, paramObj, headerObj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public virtual IRestResponse<T> ExecutePut<T>(string resource, object paramObj = null, IDictionary<string, string> headerObj = null) where T : new()
        {
            return this.Execute<T>(resource, Method.PUT, paramObj, headerObj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public virtual IRestResponse<T> ExecuteDelete<T>(string resource, object paramObj = null, IDictionary<string, string> headerObj = null) where T : new()
        {
            return this.Execute<T>(resource, Method.DELETE, paramObj, headerObj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="method"></param>
        /// <param name="callback"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public virtual RestRequestAsyncHandle ExecuteAsync(string resource, Method method, Action<IRestResponse, RestRequestAsyncHandle> callback, object paramObj = null, IDictionary<string, string> headerObj = null)
        {
            RestRequest request = new RestRequestExtensions(resource, method, new ServiceStackToJson());

            RestRequestWithParam(request, method, paramObj);
            RestRequestWithHeader(request, headerObj);

            return this.Client.ExecuteAsync(request, callback);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="callback"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public virtual RestRequestAsyncHandle ExecuteGetAsync(string resource, Action<IRestResponse, RestRequestAsyncHandle> callback, object paramObj = null, IDictionary<string, string> headerObj = null)
        {
            return this.ExecuteAsync(resource, Method.GET, callback, paramObj, headerObj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="callback"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public virtual RestRequestAsyncHandle ExecutePostAsync(string resource, Action<IRestResponse, RestRequestAsyncHandle> callback, object paramObj = null, IDictionary<string, string> headerObj = null)
        {
            return this.ExecuteAsync(resource, Method.POST, callback, paramObj, headerObj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="callback"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public virtual RestRequestAsyncHandle ExecutePutAsync(string resource, Action<IRestResponse, RestRequestAsyncHandle> callback, object paramObj = null, IDictionary<string, string> headerObj = null)
        {
            return this.ExecuteAsync(resource, Method.PUT, callback, paramObj, headerObj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="callback"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public virtual RestRequestAsyncHandle ExecuteDeleteAsync(string resource, Action<IRestResponse, RestRequestAsyncHandle> callback, object paramObj = null, IDictionary<string, string> headerObj = null)
        {
            return this.ExecuteAsync(resource, Method.DELETE, callback, paramObj, headerObj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <param name="method"></param>
        /// <param name="callback"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public virtual RestRequestAsyncHandle ExecuteAsync<T>(string resource, Method method, Action<IRestResponse<T>, RestRequestAsyncHandle> callback, object paramObj = null, IDictionary<string, string> headerObj = null)
        {
            RestRequest request = new RestRequestExtensions(resource, method, new ServiceStackToJson());

            RestRequestWithParam(request, method, paramObj);
            RestRequestWithHeader(request, headerObj);

            return this.Client.ExecuteAsync<T>(request, callback);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <param name="callback"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public virtual RestRequestAsyncHandle ExecuteGetAsync<T>(string resource, Action<IRestResponse<T>, RestRequestAsyncHandle> callback, object paramObj = null, IDictionary<string, string> headerObj = null)
        {
            return this.ExecuteAsync<T>(resource, Method.GET, callback, paramObj, headerObj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <param name="callback"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public virtual RestRequestAsyncHandle ExecutePostAsync<T>(string resource, Action<IRestResponse<T>, RestRequestAsyncHandle> callback, object paramObj = null, IDictionary<string, string> headerObj = null)
        {
            return this.ExecuteAsync<T>(resource, Method.POST, callback, paramObj, headerObj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <param name="callback"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public virtual RestRequestAsyncHandle ExecutePutAsync<T>(string resource, Action<IRestResponse<T>, RestRequestAsyncHandle> callback, object paramObj = null, IDictionary<string, string> headerObj = null)
        {
            return this.ExecuteAsync<T>(resource, Method.PUT, callback, paramObj, headerObj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource"></param>
        /// <param name="callback"></param>
        /// <param name="paramObj"></param>
        /// <param name="headerObj"></param>
        /// <returns></returns>
        public virtual RestRequestAsyncHandle ExecuteDeleteAsync<T>(string resource, Action<IRestResponse<T>, RestRequestAsyncHandle> callback, object paramObj = null, IDictionary<string, string> headerObj = null)
        {
            return this.ExecuteAsync<T>(resource, Method.DELETE, callback, paramObj, headerObj);
        }
        #endregion

        #region 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="method"></param>
        /// <param name="paramObj"></param>
        protected void RestRequestWithParam(IRestRequest request, Method method, object paramObj)
        {
            if (paramObj != null)
            {
                switch (method)
                {
                    case Method.GET:
                        request.AddGetObject(paramObj);
                        break;
                    case Method.POST:
                        request.AddJsonBody(paramObj);
                        break;
                    case Method.PUT:
                        request.AddJsonBody(paramObj);
                        break;
                    case Method.DELETE:
                        request.AddJsonBody(paramObj);
                        break;
                    default:
                        request.AddObject(paramObj);
                        break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="headerObj"></param>
        protected void RestRequestWithHeader(IRestRequest request, IDictionary<string, string> headerObj)
        {
            if (headerObj != null)
            {
                foreach (KeyValuePair<string, string> item in headerObj)
                {
                    request.AddHeader(item.Key, item.Value);
                }
            }
        }
        #endregion
    }
}
