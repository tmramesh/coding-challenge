using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCommon
{
    public class Constant
    {
        // SP Name
        public const string SP_GetLoadDetails = "[dbo].[UDP_GetLoadDetails]";

        //INPUT Params
        public const string IN_PARAMS_USER_ID = "@UserID";

        // Fields 
        public const string COLUMN_USER_NAME = "UserName";
        public const string COLUMN_LOAN_NAME = "LoanName";
        public const string COLUMN_LOAN_ID = "LoanID";
        public const string COLUMN_BALANCE = "Balance";
        public const string COLUMN_INTEREST = "Interest";
        public const string COLUMN_EARLY_FEE = "EarlyFee";
        public const string COLUMN_PAY_CARRY_OVER = "PayCarryOver";

    }
}
