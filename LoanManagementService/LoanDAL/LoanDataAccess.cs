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

        public List<Loan> GetLoanListDetails(string userID)
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
                },
                  new Loan() {   UserName = "Savarimuthu",
                           LoanName = "Loan Name 1",
                           LoanID = 2,
                           Balance = 122,
                           Interest = 21,
                           EarlyPaymentFee =1,
                           PayOutCarryOver = 223
                },
                   new Loan() {   UserName = "Ramesh 2",
                           LoanName = "Loan Name",
                           LoanID = 1,
                           Balance = 12,
                           Interest = 21,
                           EarlyPaymentFee =23,
                           PayOutCarryOver = 1
                },
                  new Loan() {   UserName = "Savarimuthu 22",
                           LoanName = "Loan Name 1",
                           LoanID = 2,
                           Balance = 122,
                           Interest = 21,
                           EarlyPaymentFee =1,
                           PayOutCarryOver = 2
                }
            };

           
        }


    }
}
