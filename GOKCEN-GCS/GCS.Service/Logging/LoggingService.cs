using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Service.Logging
{
    public static class LoggingService
    {
        private static Logger Logger { get; set; }

        public static void Init()
        {
            var config = new LoggingConfiguration();

            //[ERROR] 02-04-2025 17:32:52 > Deneme Error

            var fileTarget = new FileTarget("filePerLevel")
            {
                FileName = "logs/${level}/${shortdate}.log",
                Layout = "[${level}] ${date:format=dd.MM.yyyy HH\\:mm\\:ss} > ${message} ${exception:format=tostring}",
                ArchiveFileName = "logs/${level}/${shortdate}.{#}.log",
                MaxArchiveFiles = 10,
                ConcurrentWrites = true,
                KeepFileOpen = false
            };

            config.AddTarget(fileTarget);

            config.AddRule(LogLevel.Trace, LogLevel.Trace, fileTarget);
            config.AddRule(LogLevel.Info, LogLevel.Info, fileTarget);
            config.AddRule(LogLevel.Warn, LogLevel.Warn, fileTarget);
            config.AddRule(LogLevel.Error, LogLevel.Error, fileTarget);

            LogManager.Configuration = config;


            Logger = LogManager.GetCurrentClassLogger();
        }

        public static void Trace(string message)
        {
            Logger.Trace(message);
        }

        public static void Warn(string message)
        {
            Logger.Warn(message);
        }
        public static void Info(string message)
        {
            Logger.Info(message);
        }

        public static void Error(string message)
        {
            Logger.Error(message);
        }

    }
}
