using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCommon
{
    /// <summary>
    /// Service to deal with SQL Database
    /// </summary>
    public class SQLService :IDataService
    {
        /// <summary>
        /// Get Data from SQL database
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public DataSet GetData(string procedureName, List<SqlParameter> parameters, string connectionString = "")
        {
            DataSet dsData = new DataSet();
            try
            {
                if (string.IsNullOrEmpty(connectionString))
                {
                    connectionString = ConfigurationManager.ConnectionStrings["DBConnStr"].ConnectionString;
                }
                using (SqlConnection sqlConn = new SqlConnection(connectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(procedureName, sqlConn))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        if (parameters != null)
                        {
                            sqlCommand.Parameters.AddRange(parameters.ToArray());
                        }
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlDataAdapter.Fill(dsData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // throw here, let calling fucntion take care of logging 
                throw;
            }
          
            return dsData;
        }

        
    }
}
