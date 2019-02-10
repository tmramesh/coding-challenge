using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanModel
{
    /// <summary>
    /// Model for  holding loan information
    /// </summary>
    public class Loan
    {
        public String UserName { get; set; }
        public String LoanName { get; set; }
        public int LoanID { get; set; }
        public Decimal Balance { get; set; }
        public Decimal Interest { get; set; }
        public Decimal EarlyPaymentFee { get; set; }
        public Decimal PayOutCarryOver { get; set; }

    }
}