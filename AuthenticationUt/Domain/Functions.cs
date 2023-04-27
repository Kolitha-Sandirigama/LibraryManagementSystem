using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationUt.Domain
{
    public class Functions
    {
        public int FunctionUID { get; set; }                        // function UID
        public string FunctionName { get; set; }                    // Description
        public string UserCode { get; set; }                        // User Name

    }
}
