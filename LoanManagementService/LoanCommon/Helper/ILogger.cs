using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCommon.Helper
{
    public interface ILogger
    {
        /// <summary>
        ///  Log General Informations
        /// </summary>
        /// <param name="message"></param>
        /// <param name="priority"></param>
        /// <param name="eventID"></param>
        /// <param name="severity"></param>
        /// <param name="title"></param>
        void Log(string message, int priority = 0, int eventID = 0, TraceEventType severity = TraceEventType.Information, string title = "");

        /// <summary>
        /// Log Verbose Informations
        /// </summary>
        /// <param name="message"></param>
        /// <param name="priority"></param>
        /// <param name="eventID"></param>
        /// <param name="severity"></param>
        /// <param name="title"></param>
        void LogDebug(string message, int priority = 0, int eventID = 0, TraceEventType severity = TraceEventType.Verbose   , string title = "");

        /// <summary>
        /// Log Warnings 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="priority"></param>
        /// <param name="eventID"></param>
        /// <param name="severity"></param>
        /// <param name="title"></param>
        void LogTrace(string message, int priority = 0, int eventID = 0, TraceEventType severity = TraceEventType.Warning, string title = "");

        /// <summary>
        /// Log Error/Exceptions
        /// </summary>
        /// <param name="message"></param>
        /// <param name="priority"></param>
        /// <param name="eventID"></param>
        /// <param name="severity"></param>
        /// <param name="title"></param>
        void LogError(string message, int priority = 0, int eventID = 0, TraceEventType severity = TraceEventType.Error, string title = "");
    }
}
