using LoanCommon.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace LoanManagementService
{
    /// <summary>
    ///  Class for unhandled exception 
    /// </summary>
    public class ServiceExceptionLogger : ExceptionLogger
    {
        private ILogger logger;

        public ServiceExceptionLogger()
        {
            logger = UnityConfig.Resolve<LoanManagementLogger>();
        }

        public override void Log(ExceptionLoggerContext context)
        {
            // write a logic to pull stack trace and source and inner exception details  
            Task.Factory.StartNew(() => logger.Log(context.Exception.ToString()));
        }

    }
     

}