using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Helpers.LoggerManager
{
    public class Log : ILog
    {
        public Log()
        {
            LogManager.Setup().LoadConfigurationFromFile(string.Concat(AppDomain.CurrentDomain.BaseDirectory, "nlog.config"));
        }

        /// <summary>
        /// Instance of NLog
        /// </summary>
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private string _class { get; set; } = null!;
        private string _method { get; set; } = null!;

        /// <summary>
        /// Error type message
        /// </summary>
        /// <param name="ex"></param>
        public void LogError(Exception ex)
        {
            StackTrace stackTrace = new StackTrace(ex, true);
            StackFrame stackFrame = stackTrace.GetFrame(stackTrace.GetFrames().Count() - 1)!;
            MethodBase methodBase = stackFrame.GetMethod()!;
            GetConfiguration(methodBase);

            string mensaje = ex.Message;
            Exception innerException = ex.InnerException!;
            while (innerException != null)
            {
                mensaje = $"{mensaje}; {innerException.Message}";
                innerException = innerException.InnerException!;
            }

            logger.Error($"{_class}.{_method}:\t{mensaje}\n{innerException}");
        }

        private void GetConfiguration(MethodBase methodBase)
        {
            var array = methodBase.ReflectedType!.Name.Split('<');
            if (array.Length > 1)
            {
                _class = array[1].Split('>').FirstOrDefault()!;
                _method = methodBase.Name;
            }
            else
            {
                _class = array[0];
                _method = methodBase.Name;
            }
        }
    }
}
