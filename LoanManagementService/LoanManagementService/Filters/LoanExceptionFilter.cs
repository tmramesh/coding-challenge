using LoanCommon.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace LoanManagementService.Filters
{
    /// <summary>
    /// Custom Exception Filter
    /// </summary>
    public class LoanExceptionFilter : ExceptionFilterAttribute
    {
        private ILogger logger;

        public LoanExceptionFilter()
        {
            logger = UnityConfig.Resolve<LoanManagementLogger>();
        }

        public override void OnException(HttpActionExecutedContext context)
        {
            // Construct custome exception logic here

            Task.Factory.StartNew(() => logger.Log("Exception from application"));
        }

    }


}