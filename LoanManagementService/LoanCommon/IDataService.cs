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
    /// Provide service for Data store
    /// </summary>
    public interface IDataService
    {
        DataSet GetData(string procedureName, List<SqlParameter> parameters, string connectionString = "");
    }
}
