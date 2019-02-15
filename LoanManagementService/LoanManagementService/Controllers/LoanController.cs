using LoanCommon.Helper;
using LoanDAL;
using LoanManagementService.Filters;
using LoanModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoanManagementService.Controllers
{
    [RequireHttps]
    [LoanActionFilter]
    [LoanExceptionFilter]
    public class LoanController : ApiController
    {
        private ILoanDataAccess _loanDAL { get; set; }

        public LoanController()
        {
        }

        public LoanController(ILoanDataAccess loanDAL)
        {
            _loanDAL = loanDAL;
        }

        /// <summary>
        ///  get the loan details for the given UserID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("{userid}/loans")]
        [HttpGet]
        public IHttpActionResult GetLoans(string userId)
        {
            Stopwatch sw = Stopwatch.StartNew();
             
            var logger = UnityConfig.Resolve<ILogger>();
            var lstLoanDetails = new List<Loan>();

            logger.Log("Application started");
            try
            {
                lstLoanDetails = _loanDAL.GetLoanListDetails(userId);

                if (lstLoanDetails == null || lstLoanDetails?.Count == 0)
                {
                    return BadRequest($"Requested UserID :  { userId } is not valid, Please verify your request! "); // Not Found is returned, If repository don't have requested details. 
                }

                // return only 3 records to caller
                lstLoanDetails = lstLoanDetails?.Count > 3 ? lstLoanDetails.Take(3).ToList() : lstLoanDetails;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }

            logger.Log($"Application process time { sw.Elapsed.TotalMilliseconds } " );
            return Ok(lstLoanDetails);
        }
    }
}
