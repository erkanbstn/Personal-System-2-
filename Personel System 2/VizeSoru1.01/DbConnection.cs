using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizeSoru1._01
{
    public class DbConnection
    {
        public SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4PML7KK; Initial Catalog=Northwind; Integrated Security=TRUE");
        public SqlCommand command;
        public SqlDataReader reader;
    }
}
