using LoanCommon;
using LoanCommon.Helper;
using LoanModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanDAL
{
    /// <summary>
    /// Load Data Access for all data store's
    /// </summary>
    public class LoanDataAccess : ILoanDataAccess
    {
        ILogger logger;

        // don't allow for default - user should create with logger instance
        protected LoanDataAccess()
        {

        }

        public LoanDataAccess(ILogger logger)
        {
            this.logger = logger;
        }
        /// <summary>
        /// Get Load Details
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<Loan> GetLoanListDetails(string userID)
        {
            try
            {
                logger.Log($" GetLoanListDetails(UserID: { userID } ");

                var conString = ConfigurationManager.ConnectionStrings["DBConnStr"].ConnectionString;

                var dataService = ServiceFactory.GetService("SQL"); // TODO - move this configuration to web.Config

                // Construct Params
                var lstParam = new List<SqlParameter>() {
                                new SqlParameter() {
                                    ParameterName = Constant.IN_PARAMS_USER_ID,
                                    Value = userID,
                                    Direction =  ParameterDirection.Input
                                 }
                                };

                //Get data from Datastore
                var dsLoanList = dataService.GetData(Constant.SP_GetLoadDetails, lstParam, conString);

                // Convert DS to .NET Object
                List<Loan> lstLoan = new List<Loan>();
                lstLoan = (from DataRow dr in dsLoanList.Tables[0].Rows
                           select new Loan()
                           {
                               UserName = Convert.ToString(dr[Constant.COLUMN_USER_NAME] ?? ""),
                               LoanName = Convert.ToString(dr[Constant.COLUMN_LOAN_NAME] ?? ""),
                               LoanID = Convert.ToInt32(dr[Constant.COLUMN_LOAN_ID] ?? 0),
                               Balance = Convert.ToDecimal(dr[Constant.COLUMN_BALANCE] ?? 0),
                               Interest = Convert.ToDecimal(dr[Constant.COLUMN_INTEREST] ?? 0),
                               EarlyPaymentFee = Convert.ToDecimal(dr[Constant.COLUMN_EARLY_FEE] ?? 0),
                               PayOutCarryOver = Convert.ToDecimal(dr[Constant.COLUMN_PAY_CARRY_OVER] ?? 0),
                           }).ToList();

                return lstLoan;
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception occured in GetLoanListDetails(UserID: { userID } ) :  Exception Details: {ex.ToString() }");
                throw;
            }
   
        }
   }
}
