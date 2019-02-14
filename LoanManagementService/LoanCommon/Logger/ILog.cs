using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCommon.Logger
{
    /// <summary>
    /// Interface for writing the logs into Logger file
    /// </summary>
    public interface ILog
    {
       void Write(string message, int priority = 0, int eventID = 0, TraceEventType severity = TraceEventType.Information, string title = "");
    }
}
