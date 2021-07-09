using System;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Swashbuckle.Application;
using System.Net.Http.Formatting;
using Hangfire;
using Hangfire.SqlServer;
using Hangfire.Console;
using Microsoft.Owin.StaticFiles;
using Microsoft.Owin.FileSystems;

[assembly: OwinStartup(typeof(TaskService.Startup))]

namespace TaskService
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888
            #region Page
            var fileSystem = new PhysicalFileSystem(@".\Web"); //静态网站根目录
            var options = new FileServerOptions { EnableDefaultFiles = true, FileSystem = fileSystem };
            options.StaticFileOptions.FileSystem = fileSystem;
            options.StaticFileOptions.ServeUnknownFileTypes = true;
            options.DefaultFilesOptions.DefaultFileNames = new[] { "Index.html" }; //默认页面(填写与静态网站根目录的相对路径)
            app.UseFileServer(options);
            #endregion

            #region Web API
            HttpConfiguration config = new HttpConfiguration();

            //启用标记路由
            config.MapHttpAttributeRoutes();

            //配置默认 Web API 路由
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            //过滤器
            config.Filters.Add(new ActionLogAttribute());
            config.Filters.Add(new ActionTimeAttribute());
            config.Filters.Add(new GlobalExceptionAttribute());

            //配置Swagger
            config.EnableSwagger(C =>
            {
                C.SingleApiVersion("v1", "TaskServiceAPI");
                C.IncludeXmlComments($@"{typeof(Startup).Assembly.GetName().Name}.xml");
            }).EnableSwaggerUi(C =>
            {
                C.DocumentTitle("任务服务接口");
            });


            //将默认XML返回数据格式改为JSON
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("datatype", "json", "application/json"));

            app.UseWebApi(config);
            #endregion

            #region Hangfire
            var queues = new[] { "default", "apis", "jobs" };
            app.UseStorage(new SqlServerStorage("DotaPediaTask", new SqlServerStorageOptions { QueuePollInterval = TimeSpan.FromSeconds(1) })).UseConsole();
            app.UseHangfireFilters(new AutomaticRetryAttribute { Attempts = 0 });
            app.UseDashboardMetric();
            app.UseHangfireDashboard();
            app.UseHangfireServer(new BackgroundJobServerOptions
            {
                ShutdownTimeout = TimeSpan.FromMinutes(30),
                Queues = queues,
                WorkerCount = Math.Max(Environment.ProcessorCount, 20)
            });
            #endregion
        }
    }
}
