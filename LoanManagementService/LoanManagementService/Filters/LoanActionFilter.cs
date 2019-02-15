using LoanCommon.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace LoanManagementService.Filters
{
    /// <summary>
    /// Custom Loan Action filters - I don't have any requirement to modify ther equest or response. 
    /// So just logging the request/response into Log System
    /// </summary>
    public class LoanActionFilter : ActionFilterAttribute
    {
        private ILogger logger;
        public LoanActionFilter()
        {
            logger = UnityConfig.Resolve<LoanManagementLogger>();
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            // Add business logic  for - On Action Executing
            Task.Factory.StartNew(() => logger.Log(actionContext.ToString()));
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            // Add business logic  for - After Action Executed 
            Task.Factory.StartNew(() => logger.Log(actionExecutedContext.ToString()));
        }
    }
}