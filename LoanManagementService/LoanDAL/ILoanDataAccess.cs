using LoanModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanDAL
{
    public interface ILoanDataAccess
    {
        List<Loan> GetLoanListDetails(string userName);
    }
}
