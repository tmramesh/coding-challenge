using LoanModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanDAL
{
    public class LoanDataAccess : ILoanDataAccess
    {

        public List<Loan> GetLoanListDetails(string userName)
        {
            return  new List<Loan>()
            {
                new Loan() {   UserName = "Ramesh",
                           LoanName = "Loan Name",
                           LoanID = 1,
                           Balance = 12,
                           Interest = 21,
                           EarlyPaymentFee =23,
                           PayOutCarryOver = 333
                }
            };

           
        }


    }
}
