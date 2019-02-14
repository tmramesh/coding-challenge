using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LoanCommon.Logger
{
    /// <summary>
    /// Simple Flat File logger, use Enterprise Library Logger/log4net for better performance, customized logs, 
    /// log file over on configured size, count of file.. etc..
    /// </summary>
    public class FlatFileLogger : ILog
    {
        string filePath;

        public FlatFileLogger()
        {
            filePath =  System.IO.Path.GetTempPath() + "\\" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt";
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Dispose();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                throw;
            }
          
        }
        /// <summary>
        /// Write information to flat file 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="priority"></param>
        /// <param name="eventID"></param>
        /// <param name="severity"></param>
        /// <param name="title"></param>
        public void Write( string message, int priority = 0, int eventID = 0, TraceEventType severity = TraceEventType.Information, string title = "") 
            => WriteToFlatFile($" Title: { title }, Message : { message }, Severity : { Enum.GetName(typeof(TraceEventType), severity) }, EventID: { eventID }, priority : { priority } ");

        private async void WriteToFlatFile(string logMessage)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                await writer.WriteLineAsync(logMessage);
            }
        }
    }
}
