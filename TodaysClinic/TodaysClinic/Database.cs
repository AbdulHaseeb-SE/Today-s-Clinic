using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TodaysClinic
{
    class Database
    {
        public static SqlConnection conn = new SqlConnection("Data Source=haseeb\\sqlexpress;Initial Catalog=TodaysClinic;Integrated Security=True");
    }
}
