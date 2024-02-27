using Microsoft.Extensions.Logging;

using System;
using Newtonsoft.Json;
using ViewModels;

namespace Logger
{
    public class CustomLogger : ICustomLogger
    {
        private string CorrelationId;
        private string FunctionName;
        private string Message;
        private string Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
        private object Properties;
        private string ApplicationName = GlobalVar.ApplicationName;
        private string StatusCode;
        private string LogLevel;
        private string StackTrace;
 

        private readonly ILogger<CustomLogger> _logger;
        public CustomLogger(ILogger<CustomLogger> logger)
        {
            _logger = logger;
        }

        protected string GetCommonLog()
        {
            try
            {
                LoggerInfo loggerInfo = new LoggerInfo();
                loggerInfo.CorrelationId = CorrelationId;
                loggerInfo.FunctionName = FunctionName;
                loggerInfo.Message = Message;
                loggerInfo.StatusCode = StatusCode;
                loggerInfo.LogLevel = LogLevel;
                loggerInfo.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss");
                loggerInfo.ApplicationName = ApplicationName;
                loggerInfo.StackTrace = StackTrace;
                string jsonString = JsonConvert.SerializeObject(loggerInfo);
                jsonString = jsonString.Replace(Convert.ToString((char)34),"").Replace("{","").Replace("}","");
                string propertiesJson = JsonConvert.SerializeObject(Properties);
                return jsonString + " Properties:" + propertiesJson;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
        public void Information(CustomLog log)
        {
            try
            {
                CorrelationId = log.CorrelationId;
                Properties = log.Properties;
                FunctionName = log.FunctionName;
                Message = log.Message;
                LogLevel = LogLevels.Infomration;
                StackTrace = log.StackTrace;
                StatusCode = log.Status;
                Console.WriteLine(GetCommonLog());
                _logger.LogInformation(GetCommonLog());
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                LogLevel = LogLevels.Error;
                StatusCode = "500";
                _logger.LogError(GetCommonLog());
                throw;
            }
        }
        public void Debug(CustomLog log)
        {
            try
            {
                CorrelationId = log.CorrelationId;
                Properties = log.Properties;
                FunctionName = log.FunctionName;
                Message = log.Message;
                LogLevel = LogLevels.Debug;
                StackTrace = log.StackTrace;
                StatusCode = log.Status;
                _logger.LogDebug(GetCommonLog());
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                LogLevel = LogLevels.Error;
                StatusCode = "500";
                _logger.LogError(GetCommonLog());
                throw;
            }
        }
        public void Warning(CustomLog log)
        {
            try
            {
                CorrelationId = log.CorrelationId;
                Properties = log.Properties;
                FunctionName = log.FunctionName;
                Message = log.Message;
                LogLevel = LogLevels.Warning;
                StackTrace = log.StackTrace;
                StatusCode = log.Status;
                _logger.LogWarning(GetCommonLog());
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                LogLevel = LogLevels.Error;
                StatusCode = "500";
                _logger.LogError(GetCommonLog());
                throw;
            }
        }
        public void Error(CustomLog log)
        {
            try
            {
                CorrelationId = log.CorrelationId;
                Properties = log.Properties;
                FunctionName = log.FunctionName;
                Message = log.Message;
                StackTrace = log.StackTrace;
                LogLevel = LogLevels.Error;
                StatusCode = log.Status;
                _logger.LogError(GetCommonLog());
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                LogLevel = LogLevels.Error;
                StatusCode = "500";
                _logger.LogError(GetCommonLog());
                throw;
            }
        }
    }
    public static class LogLevels
    {
        public static string Infomration { get; } = "Information";
        public static string Debug { get; } = "Debug";
        public static string Warning { get; } = "Warning";
        public static string Error { get; } = "Error";

    }
    internal class LoggerInfo
    {
        public string Timestamp { get; set; }
        public string LogLevel { get; set; }
        public string ApplicationName { get; set; }
        public string CorrelationId { get; set; }
        public string StatusCode { get; set; }
        public string FunctionName { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; } = "";
    }
    public class CustomLog
    {
        public string CorrelationId { get; set; }
        public string Message { get; set; }
        public string FunctionName { get; set; }
        public object Properties { get; set; }
        public string StackTrace { get; set; }
        public string Status { get; set; }
    }
  

}
