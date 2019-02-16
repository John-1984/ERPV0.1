using System;
using System.Linq;

namespace LoggingModule
{
    public class Logging
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Logging()
        {
            var file = new System.IO.FileInfo(AppDomain.CurrentDomain.RelativeSearchPath + "/log4net.config");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(file);
            if (!log4net.LogManager.GetRepository().Configured)
            {
                // log4net not configured
                foreach (log4net.Util.LogLog message in log4net.LogManager.GetRepository().ConfigurationMessages.Cast<log4net.Util.LogLog>())
                {
                    // evaluate configuration message
                }
            }
        }

        public enum LoggingMode
        {
            Warning,
            Info,
            Error
        }

        public void Log(string message, Logging.LoggingMode loggingMode) { 
            if(loggingMode == LoggingMode.Error)
            {
                _log.Error(message);
            }else if(loggingMode == LoggingMode.Warning) {
                _log.Warn(message);
            }
            else {
                _log.Info(message);
            }
        }
    }
}
