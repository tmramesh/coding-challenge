using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCommon
{
    /// <summary>
    /// In Memory data service, can be used for testing 
    /// </summary>
    public class InMemoryDataService : IDataService
    {
        public DataSet GetData(string procedureName, List<SqlParameter> parameters, string connectionString = "")
        {
            // TODO - construct the data on the go and return - till that throw error
            throw new NotImplementedException();
        }
    }
}
