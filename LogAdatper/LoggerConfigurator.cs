using System;
using log4net;

namespace LogAdatper
{
    public class LoggerConfigurator
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(LoggerConfigurator));

        private static readonly Lazy<LogWrapper> Lazy = new Lazy<LogWrapper>(() => new LogWrapper(Log));

        public static LogWrapper Instance
        {
            get { return Lazy.Value; }
        }
    }
}
