using LoanCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanDAL
{
    /// <summary>
    /// Data READ/WRITE service provider 
    /// </summary>
    public class ServiceFactory
    {
        // Get Service from Factory based on config value
        public static IDataService GetService(string DataStoreType)
        {
            switch (DataStoreType)
            {
                case "SQL":
                    return new SQLService();
                //case "InMemmory": // TODO - Implement other services 
                //    return new Clerk();
                //case "ORACLE":
                //    return new Clerk();
                default:
                    return new InMemoryDataService(); // Default service provider
            }
        }
    }
}
