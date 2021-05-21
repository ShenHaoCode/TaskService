using System;

namespace TaskService
{
    /// <summary>
    /// 日志 帮助类
    /// </summary>
    public class LogHelper
    {
        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="Message"></param>
        public static void Error(string Message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("LogError");

            if (log.IsErrorEnabled)
            {
                log.Error(Message);
            }
        }

        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="ex"></param>
        public static void Error(string Message, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("LogError");

            if (log.IsErrorEnabled)
            {
                log.Error(Message, ex);
            }
        }

        /// <summary>
        /// 记录信息日志
        /// </summary>
        /// <param name="Message"></param>
        public static void Info(string Message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("LogInfo");

            if (log.IsInfoEnabled)
            {
                log.Info(Message);
            }
        }

        /// <summary>
        /// 记录信息日志
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="ex"></param>
        public static void Info(string Message, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("LogInfo");

            if (log.IsInfoEnabled)
            {
                log.Info(Message, ex);
            }
        }

        /// <summary>
        /// 记录警告日志 
        /// </summary>
        /// <param name="Message"></param>
        public static void Warn(string Message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("LogWarn");

            if (log.IsWarnEnabled)
            {
                log.Warn(Message);
            }
        }

        /// <summary>
        /// 记录警告日志
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="ex"></param>
        public static void Warn(string Message, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("LogWarn");

            if (log.IsWarnEnabled)
            {
                log.Warn(Message, ex);
            }
        }

        /// <summary>
        /// 记录调试日志 
        /// </summary>
        /// <param name="Message"></param>
        public static void Debug(string Message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("LogDebug");

            if (log.IsDebugEnabled)
            {
                log.Debug(Message);
            }
        }

        /// <summary>
        /// 记录调试日志
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="ex"></param>
        public static void Debug(string Message, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("LogDebug");

            if (log.IsDebugEnabled)
            {
                log.Debug(Message, ex);
            }
        }
    }
}
