using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using LoanCommon.Logger;


namespace LoanCommon.Helper
{
    public class LoanManagementLogger : ILogger
    {
        private static readonly ILog logSysyem;
        private static readonly ConcurrentQueue<Tuple<string, int, int, TraceEventType, string>> logQueue;

        public LoanManagementLogger()
        {
        }

        static LoanManagementLogger()
        {
            logSysyem = LogWritterFactory.GetLogger("FlatFile");
            logQueue = new ConcurrentQueue<Tuple<string, int, int, TraceEventType, string>>();
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Tuple<string, int, int, TraceEventType, string> logValaue;
                    if (logQueue.TryDequeue(out logValaue))
                    {
                        logSysyem.Write(logValaue.Item1, logValaue.Item2, logValaue.Item3,
                                        logValaue.Item4, logValaue.Item5);
                    }
                    else
                        Thread.Sleep(1000); // interval for iteration
                }
            });
        }

        public void Log(string message, int priority = 0, int eventID = 0, TraceEventType severity = TraceEventType.Information, string title = "")
            => AddToQueue(message, priority, eventID, severity, title);
       

        public void LogDebug(string message, int priority = 0, int eventID = 0, TraceEventType severity = TraceEventType.Verbose, string title = "") 
            => AddToQueue(message, priority, eventID, severity, title);

        public void LogError(string message, int priority = 0, int eventID = 0, TraceEventType severity = TraceEventType.Error, string title = "") 
            => AddToQueue(message, priority, eventID, severity, title);

        public void LogTrace(string message, int priority = 0, int eventID = 0, TraceEventType severity = TraceEventType.Warning, string title = "") 
            => AddToQueue(message, priority, eventID, severity, title);

        private static void AddToQueue(string message, int priority, int eventID, TraceEventType severity, string title)
        {
            if (!string.IsNullOrEmpty(message))
            {
                logQueue.Enqueue(new Tuple<string, int, int, TraceEventType, string>(
                        item1: message, item2: priority, item3: eventID, item4: severity, item5: title));
            }
        }
 
    }
}
