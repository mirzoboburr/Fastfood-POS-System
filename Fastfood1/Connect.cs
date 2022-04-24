using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Fastfood1
{
    internal class Connect
    {
        public static SqlConnection con;
        public void getConnection()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\source\repos\Fastfood1\Fastfood1\Database1.mdf;Integrated Security=True");

        }

    }
}
