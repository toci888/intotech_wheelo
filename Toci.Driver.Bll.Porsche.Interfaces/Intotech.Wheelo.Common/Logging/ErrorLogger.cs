using Intotech.Common;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (SwrDebug == null)
            {
                SwrDebug = new StreamWriter(DebugLogFile);
            }

            SwrDebug.Write(message + Environment.NewLine);
            SwrDebug.Flush();
        }
    }
}
