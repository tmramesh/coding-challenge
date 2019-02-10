using LoanModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanDAL
{
    /// <summary>
    /// Interface for Data Access layer
    /// </summary>
    public interface ILoanDataAccess
    {
        /// <summary>
        /// To get List of loan details for the given userID
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        List<Loan> GetLoanListDetails(string userID);
    }
}
