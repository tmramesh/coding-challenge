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
           // _loanDAL = new LoanDataAccess();
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
            List<Loan> lstLoanDetails = new List<Loan>();
            try
            {
                lstLoanDetails = _loanDAL.GetLoanListDetails(userId);

                // return only 3 records to caller
                lstLoanDetails = lstLoanDetails?.Count > 3 ? lstLoanDetails.Take<Loan>(3).ToList() : lstLoanDetails;
            }
            catch (Exception ex)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent( ex.ToString())
                };
                throw new HttpResponseException(message);
            }
            return Ok();
        }
    }
}
