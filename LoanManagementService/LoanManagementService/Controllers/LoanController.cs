using LoanDAL;
using LoanModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoanManagementService.Controllers
{
    public class LoanController : ApiController
    {
        private ILoanDataAccess _loanDAL { get; set; }

        public LoanController()
        {
            _loanDAL = new LoanDataAccess();
        }

        public LoanController(ILoanDataAccess loanDAL)
        {
            _loanDAL = loanDAL;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("{userid}/loans")]
        [HttpGet]
        public IHttpActionResult GetLoans(string userId)
        { 
            // TODO - Impelemt IOC
            return Ok(_loanDAL.GetLoanListDetails(userId));
        }
    }
}
