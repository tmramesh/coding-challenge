using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCommon.Logger
{
    /// <summary>
    /// Factory class for providing Logger instance, Could be Enterprise Looger, Log4Net, etc...
    /// </summary>
    public class LogWritterFactory 
    { 
        // Get Logger from Factory based on param value
        public static ILog GetLogger(string DataStoreType)
        {
            switch (DataStoreType)
            {
                case "FlatFile":
                    return new FlatFileLogger();
                //case "EnterpriseLibraryLogger":  
                //    return new EnterpriseLibraryLogger();
                
                default:
                    return new FlatFileLogger(); // Default Logger is Flat File Logger
            }
        }
    }
}
