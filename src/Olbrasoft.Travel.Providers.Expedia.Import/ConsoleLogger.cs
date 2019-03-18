using log4net;
using log4net.Config;
using Olbrasoft.Travel.Data.Repositories;
using System.IO;
using System.Reflection;
using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Providers.Expedia.Import
{
    public class ConsoleLogger : ILogger, ILoggingImports
    {
        protected readonly ILog Logger;

        public ConsoleLogger()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());

            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            Logger = LogManager.GetLogger(typeof(Program));
        }

        public void LogIn(Log log)
        {
            Log(log.Text);
        }

        public void Log(string message)
        {
            Logger.Info(message);
            //Console.WriteLine(message);
        }
    }
}