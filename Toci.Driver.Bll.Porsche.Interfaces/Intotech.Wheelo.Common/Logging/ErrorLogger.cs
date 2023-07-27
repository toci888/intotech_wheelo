using Intotech.Common;

namespace Intotech.Wheelo.Common.Logging
{
    public class ErrorLogger : IErrorLogger
    {
        private static string LogFile = "ErrorLogs.txt";
        private static string DebugLogFile = "DebugLogs.txt";
        private static StreamWriter Swr;
        private static StreamWriter SwrDebug;

        public virtual void Log(List<Exception> ex)
        {
            if (Swr == null)
            {
                Swr = new StreamWriter(LogFile);
            }

            string logEntry = "";

            foreach (Exception exc in ex)
            {
                logEntry += "Error. Message: " + exc.Message + ", stack trace: " + exc.StackTrace + Environment.NewLine;
            }

            Swr.Write(logEntry);
            Swr.Flush();
        }

        public virtual void Log(string message)
        {
            Log(message, LogLevels.Debug);
        }

        public virtual void Log(Exception ex, LogLevels logLevel)
        {
            List<Exception> currentExcList = new List<Exception>();

            BreakDownException(ex, currentExcList);

            if (Swr == null)
            {
                Swr = new StreamWriter(logLevel == LogLevels.Error ? LogFile : DebugLogFile);
            }

            string logEntry = "";

            foreach (Exception exc in currentExcList)
            {
                logEntry += "Error. Message: " + exc.Message + ", stack trace: " + exc.StackTrace + Environment.NewLine;
            }

            Swr.Write(logEntry);
            Swr.Flush();
        }

        public virtual void Log(string message, LogLevels logLevel)
        {
            if (SwrDebug == null)
            {
                SwrDebug = new StreamWriter(logLevel == LogLevels.Debug ? DebugLogFile : LogFile);
            }

            SwrDebug.Write(message + Environment.NewLine);
            SwrDebug.Flush();
        }

        public virtual void Log(string message, LogLevels logLevel, params object[] details)
        {
            // ? 
            List<string> detailMessages = new List<string>();

            foreach (object item in details)
            {
                detailMessages.AddRange(EntityGluer.GlueEntitiy(item));
            }

            Log(message + string.Join(" | ", detailMessages), logLevel);
        }


        protected virtual List<Exception> BreakDownException(Exception masterExc, List<Exception> currentList)
        {
            currentList.Add(masterExc);

            if (masterExc.InnerException != null)
            {
                BreakDownException(masterExc.InnerException, currentList);
            }

            return currentList;
        }
    }
}
